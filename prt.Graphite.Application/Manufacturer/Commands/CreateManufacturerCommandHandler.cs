using MediatR;
using Microsoft.EntityFrameworkCore;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Application.Common.Response;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.Manufacturer.Commands
{
    public class CreateManufacturerCommandHandler : IRequestHandler<CreateManufacturerCommand, Result<bool>>
    {
        private readonly IAppDbContext _appDbContext;

        public CreateManufacturerCommandHandler(IAppDbContext skuDbContext)
        {
            _appDbContext = skuDbContext;
        }

        public async Task<Result<bool>> Handle(CreateManufacturerCommand request, CancellationToken cancellationToken)
        {
            var manufacturer = await _appDbContext.Set<Domain.AggregatesModel.Vehicle.Entities.Manufacturer>()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (manufacturer is null)
            {
                manufacturer = new Domain.AggregatesModel.Vehicle.Entities.Manufacturer
                (
                    id: request.Id,
                    name: request.Name
                );
                await _appDbContext.Set<Domain.AggregatesModel.Vehicle.Entities.Manufacturer>()
                    .AddAsync(manufacturer, cancellationToken);
                await _appDbContext.SaveChangesAsync(cancellationToken);
            }
            return ResultHelper.Success(true);
        }
    }
}
