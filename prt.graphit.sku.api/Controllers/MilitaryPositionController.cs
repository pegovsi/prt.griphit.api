using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prt.Graphit.Api.Common.Api;
using Prt.Graphit.Application.Common.Response;
using Prt.Graphit.Application.MilitaryPosition.Commands.AddMilitaryPosition;

namespace Prt.Graphit.Api.Controllers
{
    [Route("api/v{version:apiVersion}/military-position")]
    [ApiVersion(VersionController.Version1_0)]
    [Authorize]
    public class MilitaryPositionController : BaseController
    {
        [HttpPost]
        public async Task<Result<Guid>> CreatePosition(
                   [FromBody] AddMilitaryPositionCommand command,
                   CancellationToken token)
                   => await Mediator.Send(command, token);

    }
}
