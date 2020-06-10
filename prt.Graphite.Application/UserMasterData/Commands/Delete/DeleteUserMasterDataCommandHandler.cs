using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Prt.Graphit.Application.Common.Exceptions;
using Prt.Graphit.Application.Common.Handlers;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Application.Common.Response;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.UserMasterData.Commands.Delete
{
    public class DeleteUserMasterDataCommandHandler
        : HandlerQueryBase<DeleteUserMasterDataCommand, Result<bool>>
    {
        public DeleteUserMasterDataCommandHandler(IAppDbContext appDbContext, IMapper mapper)
            : base(appDbContext, mapper)
        {
        }

        public override async Task<Result<bool>> Handle(DeleteUserMasterDataCommand request,
            CancellationToken cancellationToken)
        {
            var userMasterData = await ContextDb
                .Set<Domain.AggregatesModel.UserMasterData.Entities.UserMasterData>()
                .FirstOrDefaultAsync(x => x.Id == request.UserMasterDataId, cancellationToken);

            if (userMasterData is null)
                throw new NotFoundException($"Справочник с ключом {request.UserMasterDataId} не найден");

            ContextDb
                .Set<Domain.AggregatesModel.UserMasterData.Entities.UserMasterData>()
                .Remove(userMasterData);

            await ContextDb.SaveChangesAsync(cancellationToken);

            return ResultHelper.Success(true);
        }
    }
}
