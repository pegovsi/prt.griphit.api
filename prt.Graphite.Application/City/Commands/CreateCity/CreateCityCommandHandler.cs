using MediatR;
using Microsoft.EntityFrameworkCore;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Application.Common.Response;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.City.Commands.CreateCity
{
    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, Result<bool>>
    {
        private readonly IAppDbContext _appDbContext;

        public CreateCityCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Result<bool>> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            var city = await _appDbContext.Set<Domain.AggregatesModel.Vehicle.Entities.City>()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (city is null)
            {
                city = new Domain.AggregatesModel.Vehicle.Entities.City
                (
                    id: request.Id,
                    name: request.Name,
                    garrisonId: request.GarrisonId
                );
                await _appDbContext.Set<Domain.AggregatesModel.Vehicle.Entities.City>()
                    .AddAsync(city, cancellationToken);
                await _appDbContext.SaveChangesAsync(cancellationToken);
            }
            return ResultHelper.Success(true);
        }
    }
}
