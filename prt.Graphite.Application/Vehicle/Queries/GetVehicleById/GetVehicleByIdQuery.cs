using MediatR;
using Prt.Graphit.Application.Vehicle.Queries.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prt.Graphit.Application.Vehicle.Queries.GetVehicleById
{
    public class GetVehicleByIdQuery : IRequest<VehicleDto>
    {
        public Guid Id { get; private set; }

        public GetVehicleByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
