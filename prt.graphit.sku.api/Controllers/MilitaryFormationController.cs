using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prt.Graphit.Api.Common.Api;
using Prt.Graphit.Application.MilitaryFormation.Commands.AddMilitaryFormation;
using Prt.Graphit.Application.MilitaryFormation.Queries.GetAllMilitaryFormations;
using Prt.Graphit.Application.MilitaryFormation.Queries.Models;

namespace Prt.Graphit.Api.Controllers
{
    [Route("api/v{version:apiVersion}/military-formation")]
    [ApiVersion(VersionController.Version1_0)]
    [Authorize]
    public class MilitaryFormationController : BaseController
    {
        [HttpGet]
        public async Task<MilitaryFormationDto[]> Get()
            => await Mediator.Send(new GetAllMilitaryFormationsQuery());

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]
        AddMilitaryFormationCommand command, CancellationToken token)
        {
            var result = await Mediator.Send(command, token);
            return Ok(result);
        }
    }
}
