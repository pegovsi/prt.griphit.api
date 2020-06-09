using MediatR;
using Prt.Graphit.Application.Vehicle.Queries.Models;

namespace Prt.Graphit.Application.Vehicle.Queries.GetVehicleCounts
{
    public class GetVehicleCountsQuery : IRequest<VehicleConditionDto>
    {
        public GetVehicleCountsQuery()
        {

        }
    }
}
