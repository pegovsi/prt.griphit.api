using Prt.Graphit.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prt.Graphit.Domain.AggregatesModel.Crew.Entities
{
    /// <summary>
    /// Экипаж
    /// </summary>
    public class Crew : Entity, IAggregateRoot
    {
        protected Crew() { }

        public Crew(string OrderNumber) :base()
        {

        }

        public override Guid Id { get; protected set; }

        public string OrderNumber { get; private set; }
        public DateTime OrderDate { get; private set; }

        public DateTime OrderDateStart { get; private set; }
        public DateTime OrderDateFinish { get; private set; }

        public Guid TypesMilitaryOrderId { get; private set; }
        public TypesMilitaryOrder.Entities.TypesMilitaryOrder TypesMilitaryOrder { get; private set; }

        public Guid VehicleId { get; private set; }
        public Vehicle.Entities.Vehicle Vehicle { get; private set; }

        public Guid MilitaryFormationId { get; private set; }
        public MilitaryFormation.Entities.MilitaryFormation MilitaryFormation { get; private set; }
    }
}

