using MediatR;
using Prt.Graphit.Application.UserMasterData.Queries.Models;
using System;

namespace Prt.Graphit.Application.UserMasterData.Queries.GetUserMasterDataById
{
    public class GetUserMasterDataByIdQuery : IRequest<UserMasterDataDto>
    {
        public Guid UserMasterDataId { get; }

        public GetUserMasterDataByIdQuery(Guid userMasterDataId)
        {
            UserMasterDataId = userMasterDataId;
        }
    }
}
