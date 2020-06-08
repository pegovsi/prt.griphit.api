using Prt.Graphit.Application.MilitaryPosition.Queries.Models;
using System;

namespace Prt.Graphit.Application.VehicleModel.Queries.Models
{
    public class VehicleModelPositionDto
    {
        public Guid Id { get; private set; }
        public Guid MilitaryPositionId { get; private set; }
        public MilitaryPositionDto MilitaryPosition { get; private set; }
    }
}
