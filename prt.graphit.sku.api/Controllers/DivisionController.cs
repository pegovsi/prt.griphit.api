using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prt.Graphit.Application.Common.Response;
using Prt.Graphit.Application.Division.Commands.CreateDivision;

namespace Prt.Graphit.Sku.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/division")]
    // [ApiVersion(VersionController.Version10)]
    public class DivisionController : BaseController
    {
        //[HttpGet, Route("{id}")]
        //public async Task<ActionResult<SkuDto>> GetSkuById(Guid id)
        //    => await Mediator.Send(new GetSkuByIdQuery(id));

        [HttpPost]
        public async Task<Result<bool>> CreateDivision(
            [FromBody] CreateDivisionCommand command, 
            CancellationToken token)
            => await Mediator.Send(command, token);
    }
}