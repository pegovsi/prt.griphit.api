using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Prt.Graphit.Api.Common.Api;
using Prt.Graphit.Application.Identity.Queries.Authenticated;
using Prt.Graphit.Application.Identity.Queries.Models;

namespace Prt.Graphit.Api.Controllers
{
    [Route("api/v{version:apiVersion}/auth")]
    [ApiVersion(VersionController.Version1_0)]
    public class IdentityController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<IdentityResponse>> Auth(
            AuthenticatedQuery query, CancellationToken token)
        {
            var result = await Mediator.Send(query, token);
            if (result.Value is null)
                return new UnauthorizedObjectResult(result.Errors);
            
            return Ok(result.Value);
        }
    }
}