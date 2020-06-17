using MediatR;
using Prt.Graphit.Application.Users.Queries.Models;

namespace Prt.Graphit.Application.Users.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<UserDto[]>
    {
        public GetAllUsersQuery()
        {
            
        }
    }
}