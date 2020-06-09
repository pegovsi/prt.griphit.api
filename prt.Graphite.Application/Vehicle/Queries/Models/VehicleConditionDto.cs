namespace Prt.Graphit.Application.Vehicle.Queries.Models
{
    public class VehicleConditionDto
    {
        public int VehicleTotal { get; private set; }
        public int VehicleActive { get; private set; }
        public int VehicleDisactive { get; private set; }
        public int Approved { get; private set; }
        public decimal Readiness { get; private set; }

        public VehicleConditionDto(int vehicleTotal, int vehicleActive, int vehicleDisactive, int approved, decimal readiness)
        {
            VehicleTotal = vehicleTotal;
            VehicleActive = vehicleActive;
            VehicleDisactive = vehicleDisactive;
            Approved = approved;
            Readiness = readiness;
        }
    }
}
