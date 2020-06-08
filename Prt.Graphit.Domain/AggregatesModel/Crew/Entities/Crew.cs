using Prt.Graphit.Domain.Common;
using Prt.Graphit.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prt.Graphit.Domain.AggregatesModel.Crew.Entities
{
    /// <summary>
    /// Экипаж
    /// </summary>
    public class Crew : Entity, IAggregateRoot
    {
        protected Crew() 
        {
            _crewPositions = new List<CrewPosition>();
        }

        public Crew(string orderNumber, DateTime orderDateStart, DateTime orderDateFinish,
            Guid typesMilitaryOrderId, Guid vehicleId, Guid militaryFormationId,
            List<CrewPosition> crewPositions)
            :this()
        {
            Id = Guid.NewGuid();
            OrderNumber = orderNumber;
            OrderDateStart = orderDateStart;
            OrderDateFinish = orderDateFinish;
            TypesMilitaryOrderId = typesMilitaryOrderId;
            VehicleId = vehicleId;
            MilitaryFormationId = militaryFormationId;
            _crewPositions = crewPositions;

            AddCrewDomainEvent();
        }

        public override Guid Id { get; protected set; }

        public string OrderNumber { get; private set; }

        public DateTime OrderDateStart { get; private set; }
        public DateTime OrderDateFinish { get; private set; }

        public Guid TypesMilitaryOrderId { get; private set; }
        public TypesMilitaryOrder.Entities.TypesMilitaryOrder TypesMilitaryOrder { get; private set; }

        public Guid VehicleId { get; private set; }
        public Vehicle.Entities.Vehicle Vehicle { get; private set; }

        public Guid MilitaryFormationId { get; private set; }
        public MilitaryFormation.Entities.MilitaryFormation MilitaryFormation { get; private set; }

        private List<CrewPosition> _crewPositions;
        public IReadOnlyCollection<CrewPosition> CrewPositions => _crewPositions;

        public void AddCrewPosition(Guid militaryPositionId, Guid? accountId)
        {
            var position = _crewPositions.FirstOrDefault(x => x.MilitaryPositionId == militaryPositionId);
            if (position is null)
            {
                if (_crewPositions is null)
                    _crewPositions = new List<CrewPosition>();

                _crewPositions.Add(new CrewPosition(militaryPositionId, accountId));
            }
            else 
            {
                if (position.AccountId is null && accountId != null)
                {
                    position.SetAccount(accountId.Value);
                }
            }
        }
        public void RemoveCrewPosition(Guid militaryPositionId)
        {
            var position = _crewPositions.FirstOrDefault(x => x.MilitaryPositionId == militaryPositionId);
            if (position is null)
                return;

            _crewPositions.Remove(position);
        }

        private void AddCrewDomainEvent()
        {
            var crewUpdatedDomainEvent = new CrewUpdatedDomainEvent(this);
            base.AddDomainEvent(crewUpdatedDomainEvent);
        }
    }
}

