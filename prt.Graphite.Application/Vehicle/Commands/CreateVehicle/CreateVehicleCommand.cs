using MediatR;
using Prt.Graphit.Application.Common.Response;
using System;

namespace Prt.Graphit.Application.Vehicle.Commands.CreateVehicle
{
    public class CreateVehicleCommand : IRequest<Result<bool>>
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Guid VehicleTypeId { get; private set; }
        public Guid ChassiId { get; private set; }
        public Guid VehicleModelId { get; private set; }
        public string VehicleNomberFactory { get; private set; }
        public string VehicleNomberRegister { get; private set; }
        public string VehicleNomberChassis { get; private set; }
        public Guid ManufacturerId { get; private set; }
        public DateTime YearOfIssue { get; private set; }
        public Guid GarrisonId { get; private set; }
        public Guid CityId { get; private set; }
        public Guid DivisionId { get; private set; }
        public Guid SubdivisionId { get; private set; }
        public Guid BrigadeId { get; private set; }
        public bool IsApproved { get; private set; }
        public decimal Mileage { get; private set; }
        public decimal ShotsAmount { get; private set; }
        public decimal OperatingTime { get; private set; }
        public string ConditionId { get; private set; }
        public string Responsible { get; private set; }
        public DateTime ReadoutDate { get; private set; }
        public DateTime StartupDate { get; private set; }

        public CreateVehicleCommand(Guid id, string name, Guid vehicleTypeId, Guid chassiId, Guid vehicleModelId, string vehicleNomberFactory, string vehicleNomberRegister, string vehicleNomberChassis, Guid manufacturerId, DateTime yearOfIssue, Guid garrisonId, Guid cityId, Guid divisionId, Guid subdivisionId, Guid brigadeId, bool isApproved, decimal mileage, decimal shotsAmount, decimal operatingTime, string conditionId, string responsible, DateTime readoutDate, DateTime startupDate)
        {
            Id = id;
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
            ShotsAmount = shotsAmount;
            OperatingTime = operatingTime;
            ConditionId = conditionId;
            Responsible = responsible;
            ReadoutDate = readoutDate;
            StartupDate = startupDate;
        }
    }
}
