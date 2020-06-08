using System;

namespace Prt.Graphit.Application.VehicleModel.Queries.GetVehicleModelPage
{
    public class VehicleModelPageFilter
    {
        public Guid? VehicleModelId { get; set; }
        public Guid? VehicleTypeId { get; set; }
        public Guid? ChassisId { get; set; }
        
    }
}
