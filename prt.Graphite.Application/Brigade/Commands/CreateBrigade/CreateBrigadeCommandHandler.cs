using MediatR;
using Microsoft.EntityFrameworkCore;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Application.Common.Response;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.Brigade.Commands.CreateBrigade
{
    public class CreateBrigadeCommandHandler : IRequestHandler<CreateBrigadeCommand, Result<bool>>
    {
        private readonly ISkuDbContext _skuDbContext;

        public CreateBrigadeCommandHandler(ISkuDbContext skuDbContext)
        {
            _skuDbContext = skuDbContext;
        }

        public async Task<Result<bool>> Handle(CreateBrigadeCommand request, CancellationToken cancellationToken)
        {
            var brigade = await _skuDbContext.Set<Domain.AggregatesModel.Vehicle.Entities.Brigade>()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (brigade is null)
            {
                brigade = new Domain.AggregatesModel.Vehicle.Entities.Brigade
                (
                    id: request.Id,
                    name: request.Name,
                    divisionId: request.DivisionId
                );
                await _skuDbContext.Set<Domain.AggregatesModel.Vehicle.Entities.Brigade>()
                    .AddAsync(brigade, cancellationToken);
                await _skuDbContext.SaveChangesAsync(cancellationToken);
            }
            return ResultHelper.Success(true);
        }
    }
}
