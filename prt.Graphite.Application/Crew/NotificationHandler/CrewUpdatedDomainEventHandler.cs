using MediatR;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Domain.Events;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.Crew.NotificationHandler
{
    public class CrewUpdatedDomainEventHandler : INotificationHandler<CrewUpdatedDomainEvent>
    {
        private readonly IAppDbContext _context;

        public CrewUpdatedDomainEventHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(CrewUpdatedDomainEvent notification, CancellationToken cancellationToken)
        {
            var positions = notification
                .Crew
                .CrewPositions
                .Select(x =>
                new Domain.AggregatesModel.Crew.Entities.CrewHistoryContentPosition(x.MilitaryPositionId, x.AccountId.Value));

            var crewHistoryContent = new Domain.AggregatesModel.Crew.Entities.CrewHistoryContent
            (
                orderDate: notification.Crew.Created,
                vehicleId: notification.Crew.VehicleId,
                crewHistoryContentPositions: positions.ToList()
            );
            var crewHistory = new Domain.AggregatesModel.Crew.Entities.CrewHistory
            (
                crewId: notification.Crew.Id,
                content: crewHistoryContent
            );
            
            //await _context.DbContext.Database.ExecuteSqlInterpolatedAsync($"");

            //await _context.Set<Domain.AggregatesModel.Crew.Entities.CrewHistory>()
            //    .AddAsync(crewHistory, cancellationToken);

            //await _context.DbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
