using AutoMapper;
using Prt.Graphit.Application.Common.Handlers;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Application.Vehicle.Queries.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.Vehicle.Queries.GetVehiclesReportByCity
{
    public class GetVehiclesReportByCityQueryHandler
        : HandlerQueryBase<GetVehiclesReportByCityQuery, VehiclesCountByCityDto>
    {
        public GetVehiclesReportByCityQueryHandler(IAppDbContext appDbContext, IMapper mapper)
            : base(appDbContext, mapper)
        {
        }

        public override async Task<VehiclesCountByCityDto> Handle(GetVehiclesReportByCityQuery request, CancellationToken cancellationToken)
        {
            var vehicles = ContextDb.Set<Domain.AggregatesModel.Vehicle.Entities.Vehicle>();
            var city = ContextDb.Set<Domain.AggregatesModel.Vehicle.Entities.City>();

            var data = from v in vehicles
                       join c in city on v.CityId equals c.Id
                       group c by c.Name into g
                       select new { Name = g.Key, Count = g.Count() };

            var cities = new List<string>();
            var count = new List<int>();

            foreach (var item in data)
            {
                cities.Add(item.Name);
                count.Add(item.Count);
            }

            return new VehiclesCountByCityDto(cities.ToArray(), count.ToArray());
        }
    }
}
