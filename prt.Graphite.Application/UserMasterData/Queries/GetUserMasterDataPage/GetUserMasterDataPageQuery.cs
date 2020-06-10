using MediatR;
using Prt.Graphit.Application.Common.Paging;
using Prt.Graphit.Application.UserMasterData.Queries.Models;

namespace Prt.Graphit.Application.UserMasterData.Queries.GetUserMasterDataPage
{
    public class GetUserMasterDataPageQuery : IRequest<UserMasterDataCollectionViewModel>
    {
        public PageContext<UserMasterDataFilter> Context { get; }

        public GetUserMasterDataPageQuery(PageContext<UserMasterDataFilter> context)
        {
            Context = context;
        }
    }
}
