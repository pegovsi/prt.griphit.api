using MediatR;
using Prt.Graphit.Application.Common.Paging;
using Prt.Graphit.Application.Users.Queries.Models;

namespace Prt.Graphit.Application.Users.Queries.GetUsersPage
{
    public class GetUsersPageQuery : IRequest<UserCollectionViewModel>
    {
        public PageContext<UsersPageFilter> Context { get; }

        public GetUsersPageQuery(PageContext<UsersPageFilter> context)
        {
            Context = context;
        }
    }
}