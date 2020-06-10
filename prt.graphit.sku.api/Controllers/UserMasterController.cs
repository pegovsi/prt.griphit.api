using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prt.Graphit.Api.Common.Api;
using Prt.Graphit.Application.Common.Paging;
using Prt.Graphit.Application.Common.Response;
using Prt.Graphit.Application.UserMasterData.Commands.Create;
using Prt.Graphit.Application.UserMasterData.Commands.Delete;
using Prt.Graphit.Application.UserMasterData.Commands.Update;
using Prt.Graphit.Application.UserMasterData.Queries.GetUserMasterDataByVehicleModelId;
using Prt.Graphit.Application.UserMasterData.Queries.GetUserMasterDataPage;
using Prt.Graphit.Application.UserMasterData.Queries.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Api.Controllers
{
    [Route("api/v{version:apiVersion}/user-master-data")]
    [ApiVersion(VersionController.Version1_0)]
    [Authorize]
    public class UserMasterController : BaseController
    {
        [HttpPost, Route("page")]
        public async Task<UserMasterDataCollectionViewModel> GetPage(
            [FromBody] PageContext<UserMasterDataFilter> context, CancellationToken token)
            => await Mediator.Send(new GetUserMasterDataPageQuery(context), token);

        [HttpGet, Route("model/{id}")]
        public async Task<UserMasterDataDto[]> GetByModel(Guid id)
            => await Mediator.Send(new GetUserMasterDataByVehicleModelIdQuery(id));

        [HttpPost, Route("model/{id}")]
        public async Task<Result<Guid>> CreateByModel(
            [FromBody] CreateUserMasterDataCommand command, CancellationToken token)
            => await Mediator.Send(command, token);

        [HttpPut, Route("model/{id}")]
        public async Task<Result<bool>> UpdateByModel(
            [FromBody] UpdateUserMasterDataCommand command, CancellationToken token)
            => await Mediator.Send(command, token);

        [HttpDelete, Route("master-data/{id}")]
        public async Task<Result<bool>> DeleteByModel(
            [FromBody] DeleteUserMasterDataCommand command, CancellationToken token)
            => await Mediator.Send(command, token);
    }
}
