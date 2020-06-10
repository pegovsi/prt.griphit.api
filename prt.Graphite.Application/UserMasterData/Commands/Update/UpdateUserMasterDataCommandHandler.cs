using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Prt.Graphit.Application.Common.Exceptions;
using Prt.Graphit.Application.Common.Handlers;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Application.Common.Response;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.UserMasterData.Commands.Update
{
    public class UpdateUserMasterDataCommandHandler
        : HandlerQueryBase<UpdateUserMasterDataCommand, Result<bool>>
    {
        public UpdateUserMasterDataCommandHandler(IAppDbContext appDbContext, IMapper mapper)
            : base(appDbContext, mapper)
        {
        }

        public override async Task<Result<bool>> Handle(UpdateUserMasterDataCommand request,
            CancellationToken cancellationToken)
        {
            var userMasterData = await ContextDb
               .Set<Domain.AggregatesModel.UserMasterData.Entities.UserMasterData>()
               .FirstOrDefaultAsync(x => x.Id == request.UserMasterDataId, cancellationToken);

            if (userMasterData is null)
                throw new NotFoundException($"Справочник с ключом {request.UserMasterDataId} не найден");

            userMasterData.SetName(request.Name);

            //Удалить
            var listDeleteFields = request.UserMasterDataFields.Where(x => x.Modified == 3);
            foreach (var itemField in listDeleteFields)
            {
                var field = userMasterData.UserMasterDataFields
                    .FirstOrDefault(x => x.Id == itemField.UserMasterDataFieldId);
                if (field != null)
                    userMasterData.DeleteField(itemField.UserMasterDataFieldId);
            }

            //Создать
            var listCreateFields = request.UserMasterDataFields.Where(x => x.Modified == 1);
            foreach (var itemField in listCreateFields)
            {
                userMasterData.AddField(itemField.Name, itemField.TypeUserMasterDataId);
            }

            //Обновить
            var listUpdateFields = request.UserMasterDataFields.Where(x => x.Modified == 2);
            foreach (var itemField in listUpdateFields)
            {
                var field = userMasterData.UserMasterDataFields
                    .FirstOrDefault(x => x.Id == itemField.UserMasterDataFieldId);
                if (field is null)
                    continue;

                userMasterData.UpdateField(field.UserMasterDataId,
                    itemField.Name,
                    itemField.TypeUserMasterDataId);
            }

            ContextDb
                .Set<Domain.AggregatesModel.UserMasterData.Entities.UserMasterData>()
                .Update(userMasterData);
            await ContextDb.SaveChangesAsync(cancellationToken);

            return ResultHelper.Success(true);
        }
    }
}
