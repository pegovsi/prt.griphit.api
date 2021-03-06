﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prt.Graphit.Api.Common.Api;
using Prt.Graphit.Application.Common.Paging;
using Prt.Graphit.Application.Common.Response;
using Prt.Graphit.Application.Vehicle.Commands.AddVehiclePicture;
using Prt.Graphit.Application.Vehicle.Commands.CreateVehicle;
using Prt.Graphit.Application.Vehicle.Queries.GetAllVehicleForSelect;
using Prt.Graphit.Application.Vehicle.Queries.GetVehicleById;
using Prt.Graphit.Application.Vehicle.Queries.GetVehicleCounts;
using Prt.Graphit.Application.Vehicle.Queries.GetVehicleImage;
using Prt.Graphit.Application.Vehicle.Queries.GetVehiclesPage;
using Prt.Graphit.Application.Vehicle.Queries.GetVehiclesReportByCity;
using Prt.Graphit.Application.Vehicle.Queries.Models;
using Prt.Graphit.Application.Vehicle.Queries.SearchVehicleByName;
using System;
using System.Threading;
using System.Threading.Tasks;
using Prt.Graphit.Application.Vehicle.Commands.Update;

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
            [FromBody] SearchVehicleByNameQuery query,
            CancellationToken token)
                => await Mediator.Send(query, token);

        [HttpPost, Route("page")]
        public async Task<ActionResult<VehiclesCollectionViewModel>> GetPage(
            [FromBody] PageContext<VehiclePageFilter> context, CancellationToken token)
            => await Mediator.Send(new GetVehiclesPageQuery(context), token);


        [HttpPost, Route("picture")]
        public async Task<Result<bool>> AddPicture(
            [FromBody] AddVehiclePictureCommand command, CancellationToken token)
            => await Mediator.Send(command, token);

        [AllowAnonymous]
        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 3600)]
        [HttpGet, Route("vehicle-images/{vehicleId}/{fileName}")]
        public async Task<ActionResult> GetVehicleImage(Guid vehicleId, string fileName)
        {
            var content = await Mediator.Send(new GetVehicleImageQuery(vehicleId, fileName));
            if (content is null)
                return NotFound();

            return File(content.Data, content.ContentType, content.FileName);
        }

        [HttpGet, Route("select")]
        public async Task<VehicleShortDto[]> GetForChoose()
            => await Mediator.Send(new GetAllVehicleForSelectQuery());

        [HttpGet, Route("condition")]
        public async Task<VehicleConditionDto> GetVehiclesCondition()
            => await Mediator.Send(new GetVehicleCountsQuery());
        
        [HttpGet, Route("report-by-city")]
        public async Task<VehiclesCountByCityDto> GetVehiclesByCity()
            => await Mediator.Send(new GetVehiclesReportByCityQuery());

        [HttpPut]
        public async Task<Result<Guid>> UpdateVehicle
            ([FromBody] UpdateVehicleCommand command, CancellationToken token)
            => await Mediator.Send(command, token);
    }
}