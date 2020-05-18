using MediatR;
using Microsoft.EntityFrameworkCore;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Application.Common.Response;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.VehicleModel.Commands.CreateVehicleModel
{
    public class CreateVehicleModelCommandHandler : IRequestHandler<CreateVehicleModelCommand, Result<bool>>
    {
        private readonly IAppDbContext _appDbContext;

        public CreateVehicleModelCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Result<bool>> Handle(CreateVehicleModelCommand request, CancellationToken cancellationToken)
        {
            var vehicleModel = await _appDbContext.Set<Domain.AggregatesModel.Vehicle.Entities.VehicleModel>()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (vehicleModel is null)
            {
                vehicleModel = new Domain.AggregatesModel.Vehicle.Entities.VehicleModel
                (
                    id: request.Id,
                    name: request.Name,
                    shortName: request.ShortName,
                    vehicleModelTypeId: request.VehicleModelTypeId,
                    chassiId: request.ChassiId
                );
                await _appDbContext.Set<Domain.AggregatesModel.Vehicle.Entities.VehicleModel>()
                    .AddAsync(vehicleModel, cancellationToken);
                await _appDbContext.SaveChangesAsync(cancellationToken);
            }
            return ResultHelper.Success(true);
        }
    }
}
