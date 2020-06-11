using MediatR;
using Prt.Graphit.Application.UserMasterData.Queries.Models;

namespace Prt.Graphit.Application.UserMasterData.Queries.GetTypeUserMasterData
{
    public class GetTypeUserMasterDataQuery : IRequest<TypeUserMasterDataDto[]>
    {
    }
}
