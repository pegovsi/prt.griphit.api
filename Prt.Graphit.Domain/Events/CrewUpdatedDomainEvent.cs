using MediatR;
using Prt.Graphit.Domain.AggregatesModel.Crew.Entities;

namespace Prt.Graphit.Domain.Events
{
    public class CrewUpdatedDomainEvent : INotification
    {
        public Crew Crew { get; }

        public CrewUpdatedDomainEvent(Crew crew)
        {
            Crew = crew;
        }
    }
}
