using System;
using MediatR;
using Prt.Graphit.Application.VehicleModel.Queries.Models;

namespace Prt.Graphit.Application.VehicleModel.Queries.GetVehicleModelPositionsByVehicleId
{
    public class GetVehicleModelPositionsByVehicleIdQuery : IRequest<VehicleModelPositionDto[]>
    {
        public Guid VehicleId { get; }

        public GetVehicleModelPositionsByVehicleIdQuery(Guid vehicleId)
        {
            VehicleId = vehicleId;
        }
    }
}