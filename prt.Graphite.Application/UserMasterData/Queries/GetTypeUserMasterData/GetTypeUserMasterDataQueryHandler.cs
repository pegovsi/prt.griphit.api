using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Prt.Graphit.Application.Common.Handlers;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Application.UserMasterData.Queries.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.UserMasterData.Queries.GetTypeUserMasterData
{
    public class GetTypeUserMasterDataQueryHandler
        : HandlerQueryBase<GetTypeUserMasterDataQuery, TypeUserMasterDataDto[]>
    {
        public GetTypeUserMasterDataQueryHandler(IAppDbContext appDbContext, IMapper mapper)
            : base(appDbContext, mapper)
        {
        }

        public override async Task<TypeUserMasterDataDto[]> Handle(GetTypeUserMasterDataQuery request,
            CancellationToken cancellationToken)
        {
            var models = await ContextDb.
                Set<Domain.AggregatesModel.UserMasterData.Entities.TypeUserMasterData>()
                .ToArrayAsync(cancellationToken);

            return AutoMapper.Map<TypeUserMasterDataDto[]>(models);
        }
    }
}
