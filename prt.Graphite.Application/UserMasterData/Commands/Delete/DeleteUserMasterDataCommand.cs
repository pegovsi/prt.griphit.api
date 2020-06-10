using MediatR;
using Prt.Graphit.Application.Common.Response;
using System;

namespace Prt.Graphit.Application.UserMasterData.Commands.Delete
{
    public class DeleteUserMasterDataCommand : IRequest<Result<bool>>
    {
        public Guid UserMasterDataId { get; }

        public DeleteUserMasterDataCommand(Guid userMasterDataId)
        {
            UserMasterDataId = userMasterDataId;
        }
    }
}
