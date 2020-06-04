using MediatR;
using Prt.Graphit.Application.Map.Queries.Models;
using System;

namespace Prt.Graphit.Application.Vehicle.Queries.GetVehicleImage
{
    public class GetVehicleImageQuery : IRequest<FileContainer>
    {
        public Guid VehicleId { get; }
        public string FileName { get; }

        public GetVehicleImageQuery(Guid vehicleId, string fileName)
        {
            VehicleId = vehicleId;
            FileName = fileName;
        }
    }
}
