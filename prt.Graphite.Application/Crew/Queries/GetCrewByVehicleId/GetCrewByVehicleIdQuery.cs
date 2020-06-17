using System;
using MediatR;
using Prt.Graphit.Application.Crew.Queries.Models;

namespace Prt.Graphit.Application.Crew.Queries.GetCrewByVehicleId
{
    public class GetCrewByVehicleIdQuery : IRequest<CrewDto[]>
    {
        public Guid VehicleId { get; }

        public GetCrewByVehicleIdQuery(Guid vehicleId)
        {
            VehicleId = vehicleId;
        }
    }
}