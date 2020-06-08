using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prt.Graphit.Api.Common.Api;
using Prt.Graphit.Application.Common.Paging;
using Prt.Graphit.Application.Common.Response;
using Prt.Graphit.Application.VehicleModel.Commands.CreateVehicleModel;
using Prt.Graphit.Application.VehicleModel.Queries.GetAllVehicleModel;
using Prt.Graphit.Application.VehicleModel.Queries.GetVehicleModelById;
using Prt.Graphit.Application.VehicleModel.Queries.GetVehicleModelPage;
using Prt.Graphit.Application.VehicleModel.Queries.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Api.Controllers
{
    [Route("api/v{version:apiVersion}/vehicle-model")]
    [ApiVersion(VersionController.Version1_0)]
    [Authorize]
    public class VehicleModelController : BaseController
    {
        [HttpPost]
        public async Task<Result<bool>> CreateBrigade(
                [FromBody] CreateVehicleModelCommand command,
                CancellationToken token)
                => await Mediator.Send(command, token);

        [HttpGet]
        public async Task<VehicleModelDto[]> GetModels(CancellationToken token)
            => await Mediator.Send(new GetAllVehicleModelQuery(), token);

        [HttpGet, Route("{id}")]
        public async Task<VehicleModelDto> GetModel(Guid id, CancellationToken token)
            => await Mediator.Send(new GetVehicleModelByIdQuery(id), token);

        [HttpPost, Route("page")]
        public async Task<VehicleModelCollectionViewModel> GetPage(
            [FromBody] PageContext<VehicleModelPageFilter> context, CancellationToken token)
            => await Mediator.Send(new GetVehicleModelPageQuery(context), token);
    }
}