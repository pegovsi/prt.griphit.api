using MediatR;
using Prt.Graphit.Application.VehicleModel.Queries.Models;

namespace Prt.Graphit.Application.VehicleModel.Queries.GetAllVehicleModel
{
    public class GetAllVehicleModelQuery : IRequest<VehicleModelDto[]>
    {
        public GetAllVehicleModelQuery()
        {

        }
    }
}
