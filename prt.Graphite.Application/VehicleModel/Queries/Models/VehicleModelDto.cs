using Prt.Graphit.Application.Chassis.Queries.Models;
using Prt.Graphit.Application.VehicleType.Queries.Models;
using System;
using System.Collections.Generic;

namespace Prt.Graphit.Application.VehicleModel.Queries.Models
{
    public class VehicleModelDto
    {
        public Guid Id { get; protected set; }
        public string Name { get; private set; }
        public string ShortName { get; private set; }
        public VehicleTypeDto VehicleModelType { get; private set; }
        public ChassisDto Chassi { get; private set; }
        public string IconLink { get; private set; }
        public IEnumerable<VehicleModelPositionDto> VehicleModelPositions { get; private set; }
    }
}