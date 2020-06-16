using System;
using System.Collections.Generic;
using MediatR;
using Prt.Graphit.Application.Common.Response;

namespace Prt.Graphit.Application.Vehicle.Commands.Update
{
    public class UpdateVehicleCommand : IRequest<Result<Guid>>
    {
        public Guid VehicleId { get; }
        public string FactoryNumber { get; }
        public string Chassis { get; }
        public IEnumerable<UpdateVehicleField> Fields { get; }

        public UpdateVehicleCommand(Guid vehicleId, string factoryNumber, string chassis, IEnumerable<UpdateVehicleField> fields)
        {
            VehicleId = vehicleId;
            FactoryNumber = factoryNumber;
            Chassis = chassis;
            Fields = fields;
        }
    }

    public class UpdateVehicleField
    {
        public Guid UserMasterDataId { get; }
        public Guid UserMasterDataFieldId { get; }
        public dynamic Value { get; }

        public UpdateVehicleField(Guid userMasterDataId, Guid userMasterDataFieldId, dynamic value)
        {
            UserMasterDataId = userMasterDataId;
            UserMasterDataFieldId = userMasterDataFieldId;
            Value = value;
        }
    }
}