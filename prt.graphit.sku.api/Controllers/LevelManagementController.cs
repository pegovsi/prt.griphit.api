using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prt.Graphit.Api.Common.Api;
using Prt.Graphit.Application.LevelManagement.Queries.GetAllLevelManagement;
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
    }
}
