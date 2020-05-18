using MediatR;
using Prt.Graphit.Application.Vehicle.Queries.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prt.Graphit.Application.Vehicle.Queries.SearchVehicleByName
{
    public class SearchVehicleByNameQuery : IRequest<VehicleDto[]>
    {
        public string VehicleNameSearch { get; private set; }

        public SearchVehicleByNameQuery(string vehicleNameSearch)
        {
            VehicleNameSearch = vehicleNameSearch;
        }
    }
}
