using MediatR;
using Prt.Graphit.Application.Common.Response;
using System;

namespace Prt.Graphit.Application.VehicleType.Commands.CreateVehicleType
{
    public class CreateVehicleTypeCommand : IRequest<Result<bool>>
    {
        public CreateVehicleTypeCommand(Guid id, string name, string iconLink, string pictureLink)
        {
            Id = id;
            Name = name;
            IconLink = iconLink;
            PictureLink = pictureLink;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string IconLink { get; private set; }
        public string PictureLink { get; private set; }
    }
}
