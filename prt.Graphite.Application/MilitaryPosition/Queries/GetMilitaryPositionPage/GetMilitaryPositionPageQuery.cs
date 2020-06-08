using MediatR;
using Prt.Graphit.Application.Common.Paging;
using Prt.Graphit.Application.MilitaryPosition.Queries.Models;

namespace Prt.Graphit.Application.MilitaryPosition.Queries.GetMilitaryPositionPage
{
    public class GetMilitaryPositionPageQuery : IRequest<MilitaryPositionCollectionViewModel>
    {
        public PageContext<MilitaryPositionPageFilter> Context { get; }

        public GetMilitaryPositionPageQuery(PageContext<MilitaryPositionPageFilter> context)
        {
            Context = context;
        }
    }
}
