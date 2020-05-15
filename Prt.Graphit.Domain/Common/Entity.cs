using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prt.Graphit.Domain.Common
{
    public abstract class Entity
    {
        public virtual Guid Id { get; protected set; }
        public string CreatedBy { get; set; }

        public DateTime Created { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? Modified { get; set; }

        public DateTime? Deleted { get; set; }

        private List<INotification> _domainEvents;

        [NotMapped]
        [JsonIgnore]
        public IReadOnlyCollection<INotification> DomainEvents
            => _domainEvents?.AsReadOnly();

        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents ??= new List<INotification>();
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(INotification eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }

        public void SetDeleted() => Deleted = DateTime.Now;
    }
}
