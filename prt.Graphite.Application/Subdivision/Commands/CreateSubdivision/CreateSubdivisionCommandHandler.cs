using MediatR;
using Microsoft.EntityFrameworkCore;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Application.Common.Response;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.Subdivision.Commands.CreateSubdivision
{
    public class CreateSubdivisionCommandHandler : IRequestHandler<CreateSubdivisionCommand, Result<bool>>
    {
        private readonly ISkuDbContext _skuDbContext;

        public CreateSubdivisionCommandHandler(ISkuDbContext skuDbContext)
        {
            _skuDbContext = skuDbContext;
        }
        public async Task<Result<bool>> Handle(CreateSubdivisionCommand request, CancellationToken cancellationToken)
        {
            var subdivision = await _skuDbContext.Set<Domain.AggregatesModel.Vehicle.Entities.Subdivision>()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (subdivision is null)
            {
                subdivision = new Domain.AggregatesModel.Vehicle.Entities.Subdivision
                (
                    id: request.Id,
                    name: request.Name,
                    brigadeId: request.BrigadeId
                );
                await _skuDbContext.Set<Domain.AggregatesModel.Vehicle.Entities.Subdivision>()
                    .AddAsync(subdivision, cancellationToken);
                await _skuDbContext.SaveChangesAsync(cancellationToken);
            }
            return ResultHelper.Success(true);
        }
    }
}
