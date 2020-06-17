using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prt.Graphit.Api.Common.Api;
using Prt.Graphit.Application.Common.Paging;
using Prt.Graphit.Application.Common.Response;
using Prt.Graphit.Application.Crew.Commands.AddCrew;
using Prt.Graphit.Application.Crew.Queries.GetCrewsPage;
using Prt.Graphit.Application.Crew.Queries.Models;
using System;
using System.Threading;
using System.Threading.Tasks;
using Prt.Graphit.Application.Crew.Queries.GetCrewByVehicleId;

namespace Prt.Graphit.Api.Controllers
{
    [Route("api/v{version:apiVersion}/crew")]
    [ApiVersion(VersionController.Version1_0)]
    [Authorize]
    public class CrewController : BaseController
    {
        [HttpPost, Route("page")]
        public async Task<ActionResult<CrewCollectionViewModel>> GetPage(
           [FromBody] PageContext<CrewPageFilter> context, CancellationToken token)
           => await Mediator.Send(new GetCrewsPageQuery(context), token);
        
        [HttpPost]
        public async Task<Result<Guid>> Add(
           [FromBody] AddCrewCommand command, CancellationToken token)
           => await Mediator.Send(command, token);

        [HttpGet, Route("vehicle/{id}")]
        public async Task<CrewDto[]> GetByVehicle(Guid id)
            => await Mediator.Send(new GetCrewByVehicleIdQuery(id));
    }
}
