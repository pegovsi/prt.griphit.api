using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Prt.Graphit.Application.Common.Handlers;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Application.Crew.Queries.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Prt.Graphit.Application.Crew.Queries.GetCrewByVehicleId
{
    public class GetCrewByVehicleIdQueryHandler : 
        HandlerQueryBase<GetCrewByVehicleIdQuery, CrewDto[]>
    {
        public GetCrewByVehicleIdQueryHandler(IAppDbContext appDbContext, IMapper mapper) 
            : base(appDbContext, mapper)
        {
        }

        public override async Task<CrewDto[]> Handle(GetCrewByVehicleIdQuery request,
            CancellationToken cancellationToken)
        {
            var vehicles = ContextDb.Set<Domain.AggregatesModel.Vehicle.Entities.Vehicle>();
            var crews = ContextDb.Set<Domain.AggregatesModel.Crew.Entities.Crew>();
            var data = from c in crews
                join v in vehicles on c.VehicleId equals v.Id
                where v.Id == request.VehicleId
                select c;

            return AutoMapper.Map<CrewDto[]>(await data.ToArrayAsync(cancellationToken));
        }
    }
}