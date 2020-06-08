using MediatR;
using Prt.Graphit.Application.Common.Paging;
using Prt.Graphit.Application.Crew.Queries.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prt.Graphit.Application.Crew.Queries.GetCrewsPage
{
    public class GetCrewsPageQuery : IRequest<CrewCollectionViewModel>
    {
        public PageContext<CrewPageFilter> Context { get; }

        public GetCrewsPageQuery(PageContext<CrewPageFilter> context)
        {
            Context = context;
        }
    }
}
