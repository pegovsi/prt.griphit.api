using System;

namespace Prt.Graphit.Application.Chassis.Queries.Models
{
    public class ChassisDto
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Guid? ManufacturerId { get; private set; }
    }
}
