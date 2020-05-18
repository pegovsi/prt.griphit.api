using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prt.Graphit.Application.Common.Response;
using Prt.Graphit.Application.VehicleModel.Commands.CreateVehicleModel;

namespace Prt.Graphit.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/vehicle-model")]
    // [ApiVersion(VersionController.Version10)]
    public class VehicleModelController : BaseController
    {
        [HttpPost]
        public async Task<Result<bool>> CreateBrigade(
                [FromBody] CreateVehicleModelCommand command,
                CancellationToken token)
                => await Mediator.Send(command, token);
    }
}