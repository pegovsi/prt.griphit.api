using Microsoft.AspNetCore.Mvc;
using Prt.Graphit.Api.Common.Api;
using Prt.Graphit.Application.Common.Response;
using Prt.Graphit.Application.Sku.Commands.CreateSku;
using Prt.Graphit.Application.Sku.Models;
using Prt.Graphit.Application.Sku.Queries;
using Prt.Graphit.Application.Sku.Queries.SearchSkuByName;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Api.Controllers
{
    [Route("api/v{version:apiVersion}/sku")]
    [ApiVersion(VersionController.Version1_0)]
    public class SkuController : BaseController
    {
        [HttpGet, Route("{id}")]
        public async Task<ActionResult<SkuDto>> GetSkuById(Guid id)
            => await Mediator.Send(new GetSkuByIdQuery(id));

        [HttpPost]
        public async Task<Result<bool>> CreateSku(
            [FromBody] CreateSkuCommand command,
            CancellationToken token)
            => await Mediator.Send(command, token);

        [HttpPost, Route("search")]
        public async Task<ActionResult<SkuDto[]>> SearchSku(
            [FromBody] SearchSkuByNameQuery query,
            CancellationToken token)
            => await Mediator.Send(query, token);
    }
}