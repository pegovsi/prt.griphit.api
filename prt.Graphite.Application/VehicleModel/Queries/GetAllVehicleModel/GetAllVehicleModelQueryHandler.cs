using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Prt.Graphit.Application.Common.Handlers;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Application.VehicleModel.Queries.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.VehicleModel.Queries.GetAllVehicleModel
{
    public class GetAllVehicleModelQueryHandler : HandlerQueryBase<GetAllVehicleModelQuery, VehicleModelDto[]>
    {
        public GetAllVehicleModelQueryHandler(IAppDbContext appDbContext, IMapper mapper) 
            : base(appDbContext, mapper)
        {
        }

        public override async Task<VehicleModelDto[]> Handle(GetAllVehicleModelQuery request, CancellationToken cancellationToken)
        {
            var models = await ContextDb
                .Set<Domain.AggregatesModel.Vehicle.Entities.VehicleModel>()
                .Include(x=>x.VehicleModelPositions)
                    .ThenInclude(x=>x.MilitaryPosition)
                .ToArrayAsync(cancellationToken);

            return AutoMapper.Map<VehicleModelDto[]>(models);
        }
    }
}
