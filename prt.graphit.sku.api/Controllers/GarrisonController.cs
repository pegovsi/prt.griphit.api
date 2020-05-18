using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prt.Graphit.Application.Common.Response;
using Prt.Graphit.Application.Garrison.Commands.CreateGarrison;

namespace Prt.Graphit.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/garrison")]
    // [ApiVersion(VersionController.Version10)]
    public class GarrisonController : BaseController
    {
        [HttpPost]
        public async Task<Result<bool>> CreateGarrison(
            [FromBody] CreateGarrisonCommand command,
            CancellationToken token)
               => await Mediator.Send(command, token);
    }
}