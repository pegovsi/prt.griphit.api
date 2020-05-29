using MediatR;
using Prt.Graphit.Application.Common.Response;
using Prt.Graphit.Application.Identity.Queries.Models;

namespace Prt.Graphit.Application.Identity.Queries.Authenticated
{
    public class AuthenticatedQuery : IRequest<Result<IdentityResponse>>
    {
        public string Login { get; }
        public string Password { get; }

        public AuthenticatedQuery(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}