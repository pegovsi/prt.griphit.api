using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Prt.Graphit.Application.Common.Handlers;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Application.Vehicle.Queries.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.Vehicle.Queries.SearchVehicleByName
{
    public class SearchVehicleByNameQueryHandler : HandlerQueryBase<SearchVehicleByNameQuery, VehicleDto[]>
    {
        public SearchVehicleByNameQueryHandler(ISkuDbContext skuDbContext, IMapper mapper)
            : base(skuDbContext, mapper)
        {
        }

        public async override Task<VehicleDto[]> Handle(SearchVehicleByNameQuery request, CancellationToken cancellationToken)
        {
            var model = await ContextDb.Set<Domain.AggregatesModel.Vehicle.Entities.Vehicle>()
                .Where(x => x.Name.Contains(request.VehicleNameSearch))
                .Include(x => x.VehicleType)
                .Include(x => x.Chassis)
                .Include(x => x.VehicleModel)
                .Include(x => x.Manufacturer)
                .Include(x => x.Garrison)
                .Include(x => x.City)
                .Include(x => x.Division)
                .Include(x => x.Subdivision)
                .Include(x => x.Brigade)
                .Include(x => x.Condition)
                .ToArrayAsync(cancellationToken);

            return AutoMapper.Map<VehicleDto[]>(model);
        }
    }
}
