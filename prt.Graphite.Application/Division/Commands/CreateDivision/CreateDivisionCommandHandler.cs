using MediatR;
using Microsoft.EntityFrameworkCore;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Application.Common.Response;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.Division.Commands.CreateDivision
{
    public class CreateDivisionCommandHandler : IRequestHandler<CreateDivisionCommand, Result<bool>>
    {
        private readonly IAppDbContext _appDbContext;

        public CreateDivisionCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Result<bool>> Handle(CreateDivisionCommand request, CancellationToken cancellationToken)
        {
            var division = await _appDbContext.Set<Domain.AggregatesModel.Vehicle.Entities.Division>()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (division is null)
            {
                division = new Domain.AggregatesModel.Vehicle.Entities.Division
                (
                    id: request.Id,
                    name: request.Name
                );
                await _appDbContext.Set<Domain.AggregatesModel.Vehicle.Entities.Division>()
                    .AddAsync(division, cancellationToken);
                await _appDbContext.SaveChangesAsync(cancellationToken);
            }
            return ResultHelper.Success(true);
        }
    }
}
