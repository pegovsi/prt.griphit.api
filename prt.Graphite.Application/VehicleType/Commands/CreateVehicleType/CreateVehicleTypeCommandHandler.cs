using MediatR;
using Microsoft.EntityFrameworkCore;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Application.Common.Response;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.VehicleType.Commands.CreateVehicleType
{
    public class CreateVehicleTypeCommandHandler : IRequestHandler<CreateVehicleTypeCommand, Result<bool>>
    {
        private readonly ISkuDbContext _skuDbContext;

        public CreateVehicleTypeCommandHandler(ISkuDbContext skuDbContext)
        {
            _skuDbContext = skuDbContext;
        }

        public async Task<Result<bool>> Handle(CreateVehicleTypeCommand request, CancellationToken cancellationToken)
        {
            var vehicleType = await _skuDbContext.Set<Domain.AggregatesModel.Vehicle.Entities.VehicleType>()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (vehicleType is null)
            {
                vehicleType = new Domain.AggregatesModel.Vehicle.Entities.VehicleType
                (
                    id: request.Id,
                    name: request.Name,
                    iconLink: null,
                    pictureLink: null
                );
                await _skuDbContext.Set<Domain.AggregatesModel.Vehicle.Entities.VehicleType>()
                    .AddAsync(vehicleType, cancellationToken);
                await _skuDbContext.SaveChangesAsync(cancellationToken);
            }
            return ResultHelper.Success(true);
        }
    }
}
