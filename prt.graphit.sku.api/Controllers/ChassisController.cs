using MediatR;
using Microsoft.AspNetCore.Mvc;
using Prt.Graphit.Api.Common.Api;
using Prt.Graphit.Application.Chassis.Commands.CreateChassis;
using Prt.Graphit.Application.Common.Response;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Api.Controllers
{
    [Route("api/v{version:apiVersion}/chassis")]
    [ApiVersion(VersionController.Version1_0)]
    public class ChassisController : BaseController
    {
        [HttpPost]
        public async Task<Result<bool>> CreateBrigade(
                [FromBody] CreateChassisCommand command,
                CancellationToken token)
                => await Mediator.Send(command, token);
    }
}