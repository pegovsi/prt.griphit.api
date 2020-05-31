using System;

namespace Prt.Graphit.Application.Vehicle.Queries.GetVehiclesPage
{
    public class VehiclePageFilter
    {
        public Guid? VehicleId { get; set; }
        public string VehicleName { get; set; }
        public Guid? Garrison { get; set; }
        public Guid? Division { get; set; }
        public Guid? Subdivision { get; set; }
        public Guid? City { get; set; }
        public string Condition { get; set; }
    }
}