using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Application.Vehicle.Queries.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.Vehicle.Queries.GetVehicleById
{
    public class GetVehicleByIdQueryHandler : IRequestHandler<GetVehicleByIdQuery, VehicleDto>
    {
        private readonly IAppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public GetVehicleByIdQueryHandler(IAppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<VehicleDto> Handle(GetVehicleByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _appDbContext.Set<Domain.AggregatesModel.Vehicle.Entities.Vehicle>()
                .Include(x=>x.VehicleType)
                .Include(x=>x.Chassis)
                .Include(x=>x.VehicleModel)
                .Include(x=>x.Manufacturer)
                .Include(x=>x.Garrison)
                .Include(x=>x.City)
                .Include(x=>x.Division)
                .Include(x => x.Subdivision)
                .Include(x=>x.Brigade)
                .Include(x=>x.Condition)
                .SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            return _mapper.Map<VehicleDto>(model);
        }
    }
}
