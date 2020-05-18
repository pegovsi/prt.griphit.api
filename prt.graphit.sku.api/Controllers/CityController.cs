﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prt.Graphit.Application.City.Commands.CreateCity;
using Prt.Graphit.Application.Common.Response;

namespace Prt.Graphit.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/city")]
    // [ApiVersion(VersionController.Version10)]
    public class CityController : BaseController
    {
        [HttpPost]
        public async Task<Result<bool>> CreateBrigade(
                 [FromBody] CreateCityCommand command,
                 CancellationToken token)
                 => await Mediator.Send(command, token);

    }
}