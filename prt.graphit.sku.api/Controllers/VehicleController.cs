using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prt.Graphit.Api.Common.Api;
using Prt.Graphit.Application.Common.Paging;
using Prt.Graphit.Application.Common.Response;
using Prt.Graphit.Application.Vehicle.Commands.CreateVehicle;
using Prt.Graphit.Application.Vehicle.Queries.GetVehicleById;
using Prt.Graphit.Application.Vehicle.Queries.GetVehiclesPage;
using Prt.Graphit.Application.Vehicle.Queries.Models;
using Prt.Graphit.Application.Vehicle.Queries.SearchVehicleByName;

namespace Prt.Graphit.Api.Controllers
{
    [Route("api/v{version:apiVersion}/vehicles")]
    [ApiVersion(VersionController.Version1_0)]
    [Authorize]
    public class VehicleController : BaseController
    {
        [HttpPost]
        public async Task<Result<bool>> CreateVehicle(
                   [FromBody] CreateVehicleCommand command,
                   CancellationToken token)
                   => await Mediator.Send(command, token);

        [HttpGet, Route("{id}")]
        public async Task<VehicleDto> GetVehicle(Guid id, CancellationToken token)
                => await Mediator.Send(new GetVehicleByIdQuery(id), token);

        [HttpPost, Route("search")]
        public async Task<VehicleDto[]> SearchVehicle(
            [FromBody]SearchVehicleByNameQuery query,
            CancellationToken token)
                => await Mediator.Send(query, token);

        [HttpPost, Route("page")]
        public async Task<ActionResult<VehiclesCollectionViewModel>> GetPage(
            [FromBody] PageContext<VehiclePageFilter> context, CancellationToken token)
            => await Mediator.Send(new GetVehiclesPageQuery(context), token);

    }
}