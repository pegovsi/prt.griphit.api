using Prt.Graphit.Application.MilitaryFormation.Queries.Models;
using Prt.Graphit.Application.TypesMilitaryOrder.Queries.Models;
using Prt.Graphit.Application.Vehicle.Queries.Models;
using System;
using System.Collections.Generic;

namespace Prt.Graphit.Application.Crew.Queries.Models
{
    public class CrewDto
    {
        public Guid Id { get; private set; }

        public string OrderNumber { get; private set; }

        public DateTime OrderDateStart { get; private set; }
        public DateTime OrderDateFinish { get; private set; }

        public Guid TypesMilitaryOrderId { get; private set; }
        public TypesMilitaryOrderDto TypesMilitaryOrder { get; private set; }

        public Guid VehicleId { get; private set; }
        public VehicleShortDto Vehicle { get; private set; }

        public Guid MilitaryFormationId { get; private set; }
        public MilitaryFormationDto MilitaryFormation { get; private set; }

        public List<CrewPositionDto> CrewPositions;
    }
}
