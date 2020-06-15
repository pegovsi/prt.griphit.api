using Prt.Graphit.Domain.AggregatesModel.UserMasterData.Entities;
using Prt.Graphit.Domain.Common;
using System;
using System.Collections.Generic;

namespace Prt.Graphit.Domain.AggregatesModel.Vehicle.Entities
{
    public class Vehicle : Entity, IAggregateRoot
    {
        protected Vehicle() 
        {
            _vehiclePictures = new List<VehiclePicture>();
        }

        public Vehicle(string name)
            : this()
        {
            Id = Guid.NewGuid();
            Name = name;
            IsNew = true;
        }
        public Vehicle(string name, Guid vehicleTypeId, Guid chassiId, Guid vehicleModelId,
            string vehicleNomberFactory, string vehicleNomberRegister, string vehicleNomberChassis,
            Guid manufacturerId, DateTime yearOfIssue, Guid garrisonId, Guid cityId, Guid divisionId,
            Guid subdivisionId, Guid? brigadeId, bool isApproved, decimal mileage, decimal shotsAmoun,
            decimal operatingTime, Guid? conditionId, string responsible, DateTime readoutDate, DateTime startupDate)
            : this()
        {
            Id = Guid.NewGuid();
            IsNew = true;
            Name = name;
            VehicleTypeId = vehicleTypeId;
            ChassiId = chassiId;
            VehicleModelId = vehicleModelId;
            VehicleNomberFactory = vehicleNomberFactory;
            VehicleNomberRegister = vehicleNomberRegister;
            VehicleNomberChassis = vehicleNomberChassis;
            ManufacturerId = manufacturerId;
            YearOfIssue = yearOfIssue;
            GarrisonId = garrisonId;
            CityId = cityId;
            DivisionId = divisionId;
            SubdivisionId = subdivisionId;
            BrigadeId = brigadeId;
            IsApproved = isApproved;
            Mileage = mileage;
            ShotsAmount = shotsAmoun;
            OperatingTime = operatingTime;
            ConditionId = conditionId;
            Responsible = responsible;
            ReadoutDate = readoutDate;
            StartupDate = startupDate;
        }
        public Vehicle(Guid id, string name, Guid vehicleTypeId, Guid chassiId, Guid vehicleModelId,
            string vehicleNomberFactory, string vehicleNomberRegister, string vehicleNomberChassis,
            Guid manufacturerId, DateTime yearOfIssue, Guid garrisonId, Guid cityId, Guid divisionId,
            Guid subdivisionId, Guid? brigadeId, bool isApproved, decimal mileage, decimal shotsAmoun,
            decimal operatingTime, Guid? conditionId, string responsible, DateTime readoutDate, DateTime startupDate)
            : this()
        {
            Id = id;
            IsNew = true;
            Name = name;
            VehicleTypeId = vehicleTypeId;
            ChassiId = chassiId;
            VehicleModelId = vehicleModelId;
            VehicleNomberFactory = vehicleNomberFactory;
            VehicleNomberRegister = vehicleNomberRegister;
            VehicleNomberChassis = vehicleNomberChassis;
            ManufacturerId = manufacturerId;
            YearOfIssue = yearOfIssue;
            GarrisonId = garrisonId;
            CityId = cityId;
            DivisionId = divisionId;
            SubdivisionId = subdivisionId;
            BrigadeId = brigadeId;
            IsApproved = isApproved;
            Mileage = mileage;
            ShotsAmount = shotsAmoun;
            OperatingTime = operatingTime;
            ConditionId = conditionId;
            Responsible = responsible;
            ReadoutDate = readoutDate;
            StartupDate = startupDate;
        }

        public override Guid Id { get; protected set; }
        public string Name { get; private set; }
        public Guid VehicleTypeId { get; private set; }
        public VehicleType VehicleType { get; private set; }
        public Guid ChassiId { get; private set; }
        public Chassis Chassis { get; private set; }
        public Guid VehicleModelId { get; private set; }
        public VehicleModel VehicleModel { get; private set; }
        public string VehicleNomberFactory { get; private set; }
        public string VehicleNomberRegister { get; private set; }
        public string VehicleNomberChassis { get; private set; }
        public Guid ManufacturerId { get; private set; }
        public Manufacturer Manufacturer { get; private set; }
        public DateTime YearOfIssue { get; private set; }
        public Guid GarrisonId { get; private set; }
        public Garrison Garrison { get; private set; }
        public Guid CityId { get; private set; }
        public City City { get; private set; }
        public Guid DivisionId { get; private set; }
        public Division Division { get; private set; }
        public Guid SubdivisionId { get; private set; }
        public Subdivision Subdivision { get; private set; }
        public Guid? BrigadeId { get; private set; }
        public Brigade Brigade { get; set; }

        public bool IsApproved { get; private set; }
        public decimal Mileage { get; private set; }
        public decimal ShotsAmount { get; private set; }
        public decimal OperatingTime { get; private set; }
        public Guid? ConditionId { get; private set; }
        public Condition Condition { get; private set; }
        public string Responsible { get; private set; }
        public DateTime ReadoutDate { get; private set; }
        public DateTime StartupDate { get; private set; }

        public IEnumerable<UserMasterDataValue> UserMasterDataValue { get; private set; }

        private List<VehiclePicture> _vehiclePictures;
        public IReadOnlyCollection<VehiclePicture> VehiclePictures=> _vehiclePictures;

        public void AddPicture(string uri, string uriPreview)
        {
            _vehiclePictures.Add(new VehiclePicture(this.Id, uri, uriPreview));
        }
    }
}
