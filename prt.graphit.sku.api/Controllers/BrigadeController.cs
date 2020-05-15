﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prt.Graphit.Application.Brigade.Commands.CreateBrigade;
using Prt.Graphit.Application.Common.Response;

namespace Prt.Graphit.Sku.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/brigade")]
    // [ApiVersion(VersionController.Version10)]
    public class BrigadeController : BaseController
    {
        [HttpPost]
        public async Task<Result<bool>> CreateBrigade(
              [FromBody] CreateBrigadeCommand command,
              CancellationToken token)
              => await Mediator.Send(command, token);
    }
}