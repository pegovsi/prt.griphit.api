using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prt.Graphit.Api.Common.Api;
using Prt.Graphit.Application.Common.Paging;
using Prt.Graphit.Application.LevelManagement.Queries.GetAllLevelManagement;
using Prt.Graphit.Application.LevelManagement.Queries.GetLevelManagementById;
using Prt.Graphit.Application.LevelManagement.Queries.GetLevelManagementPage;
using Prt.Graphit.Application.LevelManagement.Queries.Models;

namespace Prt.Graphit.Api.Controllers
{
    [Route("api/v{version:apiVersion}/level-management")]
    [ApiVersion(VersionController.Version1_0)]
    [Authorize]
    public class LevelManagementController : BaseController
    {
        [HttpGet]
        public async Task<LevelManagementDto[]> Get()
            => await Mediator.Send(new GetAllLevelManagementQuery());

        [HttpPost, Route("page")]
        public async Task<ActionResult<LevelManagementCollectionViewModel>> GetPage(
           [FromBody] PageContext<LevelManagementPageFilter> context, CancellationToken token)
           => await Mediator.Send(new GetLevelManagementPage(context), token);

        [HttpGet, Route("{id}")]
        public async Task<LevelManagementDto> GetById(Guid id, CancellationToken token)
            => await Mediator.Send(new GetLevelManagementByIdQuery(id), token);
    }
}
