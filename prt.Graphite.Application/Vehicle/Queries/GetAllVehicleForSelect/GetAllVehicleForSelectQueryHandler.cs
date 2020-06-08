using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Prt.Graphit.Application.Common.Handlers;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Application.Vehicle.Queries.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.Vehicle.Queries.GetAllVehicleForSelect
{
    public class GetAllVehicleForSelectQueryHandler
        : HandlerQueryBase<GetAllVehicleForSelectQuery, VehicleShortDto[]>
    {
        public GetAllVehicleForSelectQueryHandler(IAppDbContext appDbContext, IMapper mapper)
            : base(appDbContext, mapper)
        {
        }

        public override async Task<VehicleShortDto[]> Handle(GetAllVehicleForSelectQuery request, CancellationToken cancellationToken)
        {
            var model = await ContextDb.Set<Domain.AggregatesModel.Vehicle.Entities.Vehicle>()
                .ToArrayAsync(cancellationToken);

            return AutoMapper.Map<VehicleShortDto[]>(model);
        }
    }
}
