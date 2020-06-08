using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prt.Graphit.Api.Common.Api;
using Prt.Graphit.Application.Common.Paging;
using Prt.Graphit.Application.MilitaryFormation.Commands.AddMilitaryFormation;
using Prt.Graphit.Application.MilitaryFormation.Queries.GetAllMilitaryFormations;
using Prt.Graphit.Application.MilitaryFormation.Queries.GetMilitaryFormationById;
using Prt.Graphit.Application.MilitaryFormation.Queries.GetMilitaryFormationPage;
using Prt.Graphit.Application.MilitaryFormation.Queries.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

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

        [HttpGet, Route("{id}")]
        public async Task<MilitaryFormationDto> GetById(Guid id, CancellationToken token)
            => await Mediator.Send(new GetMilitaryFormationByIdQuery(id), token);
        

        [HttpPost, Route("page")]
        public async Task<MilitaryFormationCollectionViewModel> GetPage(
           [FromBody] PageContext<MilitaryFormationPageFilter> context, CancellationToken token)
           => await Mediator.Send(new GetMilitaryFormationPageQuery(context), token);
    }
}
