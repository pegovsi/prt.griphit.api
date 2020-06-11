using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Prt.Graphit.Application.Common.Exceptions;
using Prt.Graphit.Application.Common.Handlers;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Application.UserMasterData.Queries.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.UserMasterData.Queries.GetUserMasterDataById
{
    public class GetUserMasterDataByIdQueryHandler
        : HandlerQueryBase<GetUserMasterDataByIdQuery, UserMasterDataDto>
    {
        public GetUserMasterDataByIdQueryHandler(IAppDbContext appDbContext, IMapper mapper)
            : base(appDbContext, mapper)
        {
        }

        public override async Task<UserMasterDataDto> Handle(GetUserMasterDataByIdQuery request,
            CancellationToken cancellationToken)
        {
            var model = await ContextDb.
               Set<Domain.AggregatesModel.UserMasterData.Entities.UserMasterData>()
               .Include(x => x.UserMasterDataFields)
               .Include(x => x.VehicleModel)
               .FirstOrDefaultAsync(x => x.Id == request.UserMasterDataId, cancellationToken);

            if (model is null)
                throw new NotFoundException($"Не найден справочник с ключом {request.UserMasterDataId}");

            return AutoMapper.Map<UserMasterDataDto>(model);
        }
    }
}
