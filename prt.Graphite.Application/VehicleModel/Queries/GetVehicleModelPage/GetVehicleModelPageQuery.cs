using MediatR;
using Prt.Graphit.Application.Common.Paging;
using Prt.Graphit.Application.VehicleModel.Queries.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prt.Graphit.Application.VehicleModel.Queries.GetVehicleModelPage
{
    public class GetVehicleModelPageQuery
        : IRequest<VehicleModelCollectionViewModel>
    {
        public PageContext<VehicleModelPageFilter> Context { get; }

        public GetVehicleModelPageQuery(PageContext<VehicleModelPageFilter> context)
        {
            Context = context;
        }
    }
}
