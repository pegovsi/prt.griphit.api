using Prt.Graphit.Application.Brigade.Queries.Models;
using Prt.Graphit.Application.Chassis.Queries.Models;
using Prt.Graphit.Application.City.Queries.Models;
using Prt.Graphit.Application.Condition.Queries.Models;
using Prt.Graphit.Application.Division.Queries.Models;
using Prt.Graphit.Application.Garrison.Queries.Models;
using Prt.Graphit.Application.Manufacturer.Queries.Models;
using Prt.Graphit.Application.Subdivision.Queries.Models;
using Prt.Graphit.Application.VehicleModel.Queries.Models;
using Prt.Graphit.Application.VehicleType.Queries.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prt.Graphit.Application.Vehicle.Queries.Models
{
    public class VehicleDto
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }        
        public VehicleTypeDto VehicleType { get; private set; }      
        public ChassisDto Chassis { get; private set; }       
        public VehicleModelDto VehicleModel { get; private set; }
        public string VehicleNomberFactory { get; private set; }
        public string VehicleNomberRegister { get; private set; }
        public string VehicleNomberChassis { get; private set; }
        public ManufacturerDto Manufacturer { get; private set; }
        public DateTime YearOfIssue { get; private set; }
       
        public GarrisonDto Garrison { get; private set; }
       
        public CityDto City { get; private set; }
        
        public DivisionDto Division { get; private set; }
       
        public SubdivisionDto Subdivision { get; private set; }
        
        public BrigadeDto Brigade { get; set; }

        public bool IsApproved { get; private set; }
        public decimal Mileage { get; private set; }
        public decimal ShotsAmount { get; private set; }
        public decimal OperatingTime { get; private set; }
        
        public ConditionDto Condition { get; private set; }
        public string Responsible { get; private set; }
        public DateTime ReadoutDate { get; private set; }
        public DateTime StartupDate { get; private set; }
        public IEnumerable<VehiclePictureDto> VehiclePictures { get; private set; }
    }
}
