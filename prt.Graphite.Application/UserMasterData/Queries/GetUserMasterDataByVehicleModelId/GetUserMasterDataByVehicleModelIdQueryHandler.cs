using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Prt.Graphit.Application.Common.Handlers;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Application.UserMasterData.Queries.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.UserMasterData.Queries.GetUserMasterDataByVehicleModelId
{
    public class GetUserMasterDataByVehicleModelIdQueryHandler
        : HandlerQueryBase<GetUserMasterDataByVehicleModelIdQuery, UserMasterDataDto[]>
    {
        public GetUserMasterDataByVehicleModelIdQueryHandler(IAppDbContext appDbContext, IMapper mapper)
            : base(appDbContext, mapper)
        {
        }

        public override async Task<UserMasterDataDto[]> Handle(GetUserMasterDataByVehicleModelIdQuery request,
            CancellationToken cancellationToken)
        {
            var models = await ContextDb
                .Set<Domain.AggregatesModel.UserMasterData.Entities.UserMasterData>()
                .Include(x => x.UserMasterDataFields)
                .ThenInclude(x => x.TypeUserMasterData)
                .Where(x => x.VehicleModelId == request.VehicleModelId)
                .ToArrayAsync(cancellationToken);

            return AutoMapper.Map<UserMasterDataDto[]>(models);
        }
    }
}
