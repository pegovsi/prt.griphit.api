using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prt.Graphit.Api.Common.Api;
using Prt.Graphit.Application.Common.Paging;
using Prt.Graphit.Application.Users.Queries.GetAllUsers;
using Prt.Graphit.Application.Users.Queries.GetUsersPage;
using Prt.Graphit.Application.Users.Queries.Models;

namespace Prt.Graphit.Api.Controllers
{
    [Route("api/v{version:apiVersion}/users")]
    [ApiVersion(VersionController.Version1_0)]
    [Authorize]
    public class UserController : BaseController
    {
        [HttpPost, Route("page")]
        public async Task<ActionResult<UserCollectionViewModel>> GetPage(
            [FromBody] PageContext<UsersPageFilter> context, CancellationToken token)
            => await Mediator.Send(new GetUsersPageQuery(context), token);
     
        [HttpGet]
        public async Task<UserDto[]> GetAll(CancellationToken token)
            => await Mediator.Send(new GetAllUsersQuery(), token);
    }
}