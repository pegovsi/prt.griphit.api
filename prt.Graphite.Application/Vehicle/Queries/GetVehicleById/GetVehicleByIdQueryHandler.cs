using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Application.Vehicle.Queries.Models;
using Prt.Graphit.Domain.Views;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.Vehicle.Queries.GetVehicleById
{
    public class GetVehicleByIdQueryHandler : IRequestHandler<GetVehicleByIdQuery, VehicleDto>
    {
        private readonly IAppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public GetVehicleByIdQueryHandler(IAppDbContext appDbContext
            , IMapper mapper
            )
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<VehicleDto> Handle(GetVehicleByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _appDbContext
                .Set<Domain.AggregatesModel.Vehicle.Entities.Vehicle>()
                .AsNoTracking()
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
                .Include(x => x.VehiclePictures)
                .Include(x=>x.UserMasterDataValue)
                .SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            var userMasterDataWithFields = await _appDbContext
                .Set<Domain.AggregatesModel.UserMasterData.Entities.UserMasterData>()
                .Where(x => x.VehicleModelId == model.VehicleModelId)
                .Include(x=>x.UserMasterDataFields).ThenInclude(p=>p.TypeUserMasterData)
                .ToArrayAsync(cancellationToken);

            model.VehicleModel.Include(userMasterDataWithFields);

            return _mapper.Map<VehicleDto>(model);
        }
    }
}
