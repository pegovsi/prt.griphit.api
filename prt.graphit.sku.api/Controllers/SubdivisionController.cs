using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prt.Graphit.Application.Common.Response;
using Prt.Graphit.Application.Subdivision.Commands.CreateSubdivision;

namespace Prt.Graphit.Sku.Api.Controllers
{
    [Route("api/v{version:apiVersion}/subdivision")]
    // [ApiVersion(VersionController.Version10)]
    public class SubdivisionController : BaseController
    {
        [HttpPost]
        public async Task<Result<bool>> CreateSubdivision(
                   [FromBody] CreateSubdivisionCommand command,
                   CancellationToken token)
                   => await Mediator.Send(command, token);
    }
}