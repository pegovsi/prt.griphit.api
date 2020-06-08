using MediatR;
using Prt.Graphit.Application.Common.Paging;
using Prt.Graphit.Application.MilitaryFormation.Queries.Models;

namespace Prt.Graphit.Application.MilitaryFormation.Queries.GetMilitaryFormationPage
{
    public class GetMilitaryFormationPageQuery : IRequest<MilitaryFormationCollectionViewModel>
    {
        public PageContext<MilitaryFormationPageFilter> Context { get; }

        public GetMilitaryFormationPageQuery(PageContext<MilitaryFormationPageFilter> context)
        {
            Context = context;
        }
    }
}
