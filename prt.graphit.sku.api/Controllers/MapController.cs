using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prt.Graphit.Api.Common.Api;
using Prt.Graphit.Application.Map.Queries.GetTitle;

namespace Prt.Graphit.Api.Controllers
{
    [Route("api/v1/map")]
    [ApiVersion(VersionController.Version1_0)]    
    public class MapController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Get(string z, string x, string y, CancellationToken token)
        {
            var query = new GetTitleQuery(z, x, y);
            var content = await Mediator.Send(query, token);

            if (content is null)
                return NotFound();

            return File(content.Data, content.ContentType, content.FileName);
        }
    }
}
