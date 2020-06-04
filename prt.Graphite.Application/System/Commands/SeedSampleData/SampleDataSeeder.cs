using Microsoft.EntityFrameworkCore;
using Prt.Graphit.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.System.Commands.SeedSampleData
{
    public class SampleDataSeeder
    {
        private readonly IAppDbContext _context;

        public SampleDataSeeder(IAppDbContext context)
        {
            _context = context;
        }

        public async Task SeedAllAsync(CancellationToken token)
        {
            await SeedConditionsAsync(token);
        }

        private async Task SeedConditionsAsync(CancellationToken token)
        {
            var conditions = await _context
                .DbContext
                .Set<Domain.AggregatesModel.Vehicle.Entities.Condition>()
                .ToListAsync(token);

            if (!conditions.Any())
            {
                conditions = new List<Domain.AggregatesModel.Vehicle.Entities.Condition> 
                {
                    new Domain.AggregatesModel.Vehicle.Entities.Condition("Исправен", null, true),
                    new Domain.AggregatesModel.Vehicle.Entities.Condition("Неисправен", null, false),
                    new Domain.AggregatesModel.Vehicle.Entities.Condition("НеОбслуживался", null, false),
                };

                await _context
                .DbContext
                .Set<Domain.AggregatesModel.Vehicle.Entities.Condition>()
                .AddRangeAsync(conditions);

                await _context.SaveChangesAsync(token);
            }
        }
    }
}
