using MediatR;
using Microsoft.EntityFrameworkCore;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Application.Common.Response;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.Garrison.Commands.CreateGarrison
{
    public class CreateGarrisonCommandHandler : IRequestHandler<CreateGarrisonCommand, Result<bool>>
    {
        private readonly IAppDbContext _appDbContext;

        public CreateGarrisonCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Result<bool>> Handle(CreateGarrisonCommand request, CancellationToken cancellationToken)
        {
            var garrison = await _appDbContext.Set<Domain.AggregatesModel.Vehicle.Entities.Garrison>()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (garrison is null)
            {
                garrison = new Domain.AggregatesModel.Vehicle.Entities.Garrison
                (
                    id: request.Id,
                    name: request.Name,
                    coordinateX: request.CoordinateX,
                    coordinateY: request.CoordinateY,
                    rate: request.Rate
                );
                await _appDbContext.Set<Domain.AggregatesModel.Vehicle.Entities.Garrison>()
                    .AddAsync(garrison, cancellationToken);
                await _appDbContext.SaveChangesAsync(cancellationToken);
            }
            return ResultHelper.Success(true);
        }
    }
}
