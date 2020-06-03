using MediatR;
using Prt.Graphit.Application.Common.Response;
using System;
using System.Collections.Generic;

namespace Prt.Graphit.Application.Vehicle.Commands.AddVehiclePicture
{
    public class AddVehiclePictureCommand : IRequest<Result<bool>>
    {
        public Guid VehicleId { get; }
        public IEnumerable<Pictures> Pictures { get; }

        public AddVehiclePictureCommand(Guid vehicleId, IEnumerable<Pictures> pictures)
        {
            VehicleId = vehicleId;
            Pictures = pictures;
        }
    }

    public class Pictures
    {
        public string Uri { get; set; }
        public string UriPreview { get; set; }
    }
}
