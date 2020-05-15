using Microsoft.AspNetCore.Mvc;
using Prt.Graphit.Application.Sku.Models;
using Prt.Graphit.Application.Sku.Queries;
using System;
using System.Threading.Tasks;

namespace Prt.Graphit.Sku.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/sku")]
    // [ApiVersion(VersionController.Version10)]
    public class SkuController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<SkuDto>> GetSkuById(Guid id)
            => await Mediator.Send(new GetSkuByIdQuery(id));
    }
}