using MediatR;
using Prt.Graphit.Application.Vehicle.Queries.Models;

namespace Prt.Graphit.Application.Vehicle.Queries.GetVehiclesReportByCity
{
    public class GetVehiclesReportByCityQuery : IRequest<VehiclesCountByCityDto>
    {
    }
}
