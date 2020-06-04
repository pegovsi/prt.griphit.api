using MediatR;
using Prt.Graphit.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.System.Commands.SeedSampleData
{
    public class SeedSampleDataCommand : IRequest
    {
    }

    public class SeedSampleDataCommandHandler : IRequestHandler<SeedSampleDataCommand, Unit>
    {
        private readonly IAppDbContext _context;

        public SeedSampleDataCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(SeedSampleDataCommand request, CancellationToken cancellationToken)
        {
            var seeder = new SampleDataSeeder(_context);

            await seeder.SeedAllAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
