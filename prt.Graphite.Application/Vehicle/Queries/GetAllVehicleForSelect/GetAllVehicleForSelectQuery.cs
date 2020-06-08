using MediatR;
using Prt.Graphit.Application.Vehicle.Queries.Models;

namespace Prt.Graphit.Application.Vehicle.Queries.GetAllVehicleForSelect
{
    public class GetAllVehicleForSelectQuery : IRequest<VehicleShortDto[]>
    {
        public GetAllVehicleForSelectQuery()
        {

        }
    }
}
