using MediatR;
using Prt.Graphit.Application.Common.Response;
using System;
using System.Collections.Generic;

namespace Prt.Graphit.Application.Crew.Commands.AddCrew
{
    public class AddCrewCommand : IRequest<Result<Guid>>
    {
        public string OrderNumber { get; }
        public DateTime OrderDateStart { get; }
        public DateTime OrderDateFinish { get; }
        public Guid TypesMilitaryOrderId { get; }
        public Guid VehicleId { get; }
        public Guid MilitaryFormationId { get; }
        public IEnumerable<CrewPosition> CrewPositions { get; }

        public AddCrewCommand(string orderNumber, DateTime orderDateStart, DateTime orderDateFinish, Guid typesMilitaryOrderId, Guid vehicleId, Guid militaryFormationId, IEnumerable<CrewPosition> crewPositions)
        {
            OrderNumber = orderNumber;
            OrderDateStart = orderDateStart;
            OrderDateFinish = orderDateFinish;
            TypesMilitaryOrderId = typesMilitaryOrderId;
            VehicleId = vehicleId;
            MilitaryFormationId = militaryFormationId;
            CrewPositions = crewPositions;
        }
    }

    public class CrewPosition
    {
        public Guid MilitaryPositionId { get; private set; }
        public Guid? AccountId { get; private set; }

        public CrewPosition(Guid militaryPositionId, Guid? accountId)
        {
            MilitaryPositionId = militaryPositionId;
            AccountId = accountId;
        }
    }
}
