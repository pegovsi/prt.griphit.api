using MediatR;
using Prt.Graphit.Application.Common.Paging;

namespace Prt.Graphit.Application.Vehicle.Queries.GetVehiclesPage
{
    public class GetVehiclesPageQuery : IRequest<VehiclesCollectionViewModel>
    {
        public PageContext<VehiclePageFilter> Context { get; }

        public GetVehiclesPageQuery(PageContext<VehiclePageFilter> context)
        {
            Context = context;
        }
    }
}