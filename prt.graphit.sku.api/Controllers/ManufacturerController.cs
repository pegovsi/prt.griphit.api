using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prt.Graphit.Api.Common.Api;
using Prt.Graphit.Application.Common.Response;
using Prt.Graphit.Application.Manufacturer.Commands;

namespace Prt.Graphit.Api.Controllers
{
    [Route("api/v{version:apiVersion}/manufacturer")]
    [ApiVersion(VersionController.Version1_0)]
    public class ManufacturerController : BaseController
    {
        [HttpPost]
        public async Task<Result<bool>> CreateManufacturer(
              [FromBody] CreateManufacturerCommand command,
              CancellationToken token)
              => await Mediator.Send(command, token);
    }
}