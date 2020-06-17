using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Prt.Graphit.Application.Common.Handlers;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Application.Users.Queries.Models;

namespace Prt.Graphit.Application.Users.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : HandlerQueryBase<GetAllUsersQuery, UserDto[]>
    {
        public GetAllUsersQueryHandler(IAppDbContext appDbContext, IMapper mapper) 
            : base(appDbContext, mapper)
        {
        }

        public override async Task<UserDto[]> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {

            var users = await ContextDb.Set<Domain.AggregatesModel.Account.Entities.Account>()
                .ToArrayAsync(cancellationToken);
            return AutoMapper.Map<UserDto[]>(users);
        }
    }
}