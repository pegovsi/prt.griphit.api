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
using Prt.Graphit.Application.VehicleType.Commands.CreateVehicleType;

namespace Prt.Graphit.Api.Controllers
{
    [Route("api/v{version:apiVersion}/vehicle-type")]
    [ApiVersion(VersionController.Version1_0)]
    [Authorize]
    public class VehicleTypeController : BaseController
    {
        [HttpPost]
        public async Task<Result<bool>> CreateBrigade(
                [FromBody] CreateVehicleTypeCommand command,
                CancellationToken token)
                => await Mediator.Send(command, token);
    }
}