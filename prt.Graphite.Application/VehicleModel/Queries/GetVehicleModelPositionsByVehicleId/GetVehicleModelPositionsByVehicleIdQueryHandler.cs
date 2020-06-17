using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Prt.Graphit.Application.Common.Handlers;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Application.VehicleModel.Queries.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Prt.Graphit.Application.VehicleModel.Queries.GetVehicleModelPositionsByVehicleId
{
    public class GetVehicleModelPositionsByVehicleIdQueryHandler
    : HandlerQueryBase<GetVehicleModelPositionsByVehicleIdQuery, VehicleModelPositionDto[]>
    {
        public GetVehicleModelPositionsByVehicleIdQueryHandler(IAppDbContext appDbContext, IMapper mapper) 
            : base(appDbContext, mapper)
        {
        }

        public override async Task<VehicleModelPositionDto[]> Handle(GetVehicleModelPositionsByVehicleIdQuery request,
            CancellationToken cancellationToken)
        {
            var vahicles = ContextDb.Set<Domain.AggregatesModel.Vehicle.Entities.Vehicle>();

            var vehicleModelPositions =
                ContextDb.Set<Domain.AggregatesModel.Vehicle.Entities.VehicleModelPosition>()
                    .Include(x=>x.MilitaryPosition);
            
            var models = ContextDb.Set<Domain.AggregatesModel.Vehicle.Entities.VehicleModel>();
            

            var data =
                from vp in vehicleModelPositions
                join v in vahicles on vp.VehicleModelId equals v.VehicleModelId
                where v.Id == request.VehicleId
                select vp;


            return AutoMapper.Map<VehicleModelPositionDto[]>(data);
        }
    }
}