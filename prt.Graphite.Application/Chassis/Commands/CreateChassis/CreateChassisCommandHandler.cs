using MediatR;
using Microsoft.EntityFrameworkCore;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Application.Common.Response;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.Chassis.Commands.CreateChassis
{
    public class CreateChassisCommandHandler : IRequestHandler<CreateChassisCommand, Result<bool>>
    {
        private readonly ISkuDbContext _skuDbContext;

        public CreateChassisCommandHandler(ISkuDbContext skuDbContext)
        {
            _skuDbContext = skuDbContext;
        }

        public async Task<Result<bool>> Handle(CreateChassisCommand request, CancellationToken cancellationToken)
        {
            var chassis = await _skuDbContext.Set<Domain.AggregatesModel.Vehicle.Entities.Chassis>()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (chassis is null)
            {
                chassis = new Domain.AggregatesModel.Vehicle.Entities.Chassis
                (
                    id: request.Id,
                    name: request.Name,
                    manufacturerId: request.ManufacturerId.Value
                );
                await _skuDbContext.Set<Domain.AggregatesModel.Vehicle.Entities.Chassis>()
                    .AddAsync(chassis, cancellationToken);
                await _skuDbContext.SaveChangesAsync(cancellationToken);
            }
            return ResultHelper.Success(true);
        }
    }
}
