using Prt.Graphit.Domain.Common;
using System;

namespace Prt.Graphit.Domain.AggregatesModel.Vehicle.Entities
{
    public class VehicleModelPosition : Entity
    {
        protected VehicleModelPosition() { }

        public override Guid Id { get; protected set; }
        public Guid MilitaryPositionId { get; private set; }
        public MilitaryPosition.Entities.MilitaryPosition MilitaryPosition { get; private set; }
    }
}
