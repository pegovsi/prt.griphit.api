using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Prt.Graphit.Application.Common.Handlers;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Application.VehicleModel.Queries.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.VehicleModel.Queries.GetVehicleModelById
{
    public class GetVehicleModelByIdQueryHandler : HandlerQueryBase<GetVehicleModelByIdQuery, VehicleModelDto>
    {
        public GetVehicleModelByIdQueryHandler(IAppDbContext appDbContext, IMapper mapper)
            : base(appDbContext, mapper)
        {
        }

        public override async Task<VehicleModelDto> Handle(GetVehicleModelByIdQuery request,
            CancellationToken cancellationToken)
        {
            var model = await ContextDb
                .Set<Domain.AggregatesModel.Vehicle.Entities.VehicleModel>()
                .Include(x => x.VehicleModelPositions)
                    .ThenInclude(x => x.MilitaryPosition)
                .FirstOrDefaultAsync(x => x.Id == request.VehicleModelId, cancellationToken);

            return AutoMapper.Map<VehicleModelDto>(model);
        }
    }
}
