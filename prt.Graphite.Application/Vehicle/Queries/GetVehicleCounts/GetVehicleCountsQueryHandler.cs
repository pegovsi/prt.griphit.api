using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Prt.Graphit.Application.Common.Handlers;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Application.Vehicle.Queries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.Vehicle.Queries.GetVehicleCounts
{
    public class GetVehicleCountsQueryHandler : HandlerQueryBase<GetVehicleCountsQuery, VehicleConditionDto>
    {
        public GetVehicleCountsQueryHandler(IAppDbContext appDbContext, IMapper mapper) 
            : base(appDbContext, mapper)
        {
        }

        public override async Task<VehicleConditionDto> Handle(GetVehicleCountsQuery request,
            CancellationToken cancellationToken)
        {
            var conditions = await ContextDb
                .Set<Domain.AggregatesModel.Vehicle.Entities.Condition>()
                .ToArrayAsync(cancellationToken);

            var isGood = conditions.FirstOrDefault(x => x.Name == "Исправен");
            var isNoGood = conditions.FirstOrDefault(x => x.Name == "Неисправен");

            var vehicles = ContextDb
                .DbContext
                .Set<Domain.AggregatesModel.Vehicle.Entities.Vehicle>();
                        
            var active = vehicles.Where(x =>x.ConditionId == isGood.Id).Count();
            var disactive = vehicles.Where(x => x.ConditionId == isNoGood.Id).Count();
            int approved = vehicles.Where(x => x.IsApproved == true).Count();
            var count = vehicles.Count();
            
            decimal readiness = (active * 100) / count;
            readiness = Math.Round(readiness, MidpointRounding.ToEven);

            return new VehicleConditionDto(count, active, disactive, approved, readiness);
        }
    }
}
