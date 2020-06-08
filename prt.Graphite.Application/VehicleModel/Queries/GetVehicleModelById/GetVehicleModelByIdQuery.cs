using MediatR;
using Prt.Graphit.Application.VehicleModel.Queries.Models;
using System;

namespace Prt.Graphit.Application.VehicleModel.Queries.GetVehicleModelById
{
    public class GetVehicleModelByIdQuery : IRequest<VehicleModelDto>
    {
        public Guid VehicleModelId { get; }

        public GetVehicleModelByIdQuery(Guid vehicleModelId)
        {
            VehicleModelId = vehicleModelId;
        }
    }
}
