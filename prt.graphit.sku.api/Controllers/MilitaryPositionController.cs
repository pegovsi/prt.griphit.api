using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prt.Graphit.Api.Common.Api;
using Prt.Graphit.Application.Common.Paging;
using Prt.Graphit.Application.Common.Response;
using Prt.Graphit.Application.MilitaryPosition.Commands.AddMilitaryPosition;
using Prt.Graphit.Application.MilitaryPosition.Queries.GetAllMilitaryPosition;
using Prt.Graphit.Application.MilitaryPosition.Queries.GetMilitaryPositionById;
using Prt.Graphit.Application.MilitaryPosition.Queries.GetMilitaryPositionPage;
using Prt.Graphit.Application.MilitaryPosition.Queries.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

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

        [HttpGet]
        public async Task<MilitaryPositionDto[]> Get()
            => await Mediator.Send(new GetAllMilitaryPositionQuery());

        [HttpGet, Route("{id}")]
        public async Task<MilitaryPositionDto> GetById(Guid id, CancellationToken token)
            => await Mediator.Send(new GetMilitaryPositionByIdQuery(id), token);

        [HttpPost, Route("page")]
        public async Task<MilitaryPositionCollectionViewModel> GetPage(
           [FromBody] PageContext<MilitaryPositionPageFilter> context, CancellationToken token)
           => await Mediator.Send(new GetMilitaryPositionPageQuery(context), token);
    }
}
