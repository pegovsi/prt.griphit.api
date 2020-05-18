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
        private readonly ISkuDbContext _skuDbContext;

        public CreateVehicleModelCommandHandler(ISkuDbContext skuDbContext)
        {
            _skuDbContext = skuDbContext;
        }

        public async Task<Result<bool>> Handle(CreateVehicleModelCommand request, CancellationToken cancellationToken)
        {
            var vehicleModel = await _skuDbContext.Set<Domain.AggregatesModel.Vehicle.Entities.VehicleModel>()
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
                await _skuDbContext.Set<Domain.AggregatesModel.Vehicle.Entities.VehicleModel>()
                    .AddAsync(vehicleModel, cancellationToken);
                await _skuDbContext.SaveChangesAsync(cancellationToken);
            }
            return ResultHelper.Success(true);
        }
    }
}
