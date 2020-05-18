using MediatR;
using Prt.Graphit.Application.Common.Response;
using System;

namespace Prt.Graphit.Application.VehicleModel.Commands.CreateVehicleModel
{
    public class CreateVehicleModelCommand : IRequest<Result<bool>>
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string ShortName { get; private set; }
        public Guid VehicleModelTypeId { get; private set; }
        public Guid ChassiId { get; private set; }
        public string IconLink { get; private set; }

        public CreateVehicleModelCommand(Guid id, string name, string shortName, Guid vehicleModelTypeId, Guid chassiId, string iconLink)
        {
            Id = id;
            Name = name;
            ShortName = shortName;
            VehicleModelTypeId = vehicleModelTypeId;
            ChassiId = chassiId;
            IconLink = iconLink;
        }
    }
}
