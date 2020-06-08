using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Prt.Graphit.Application.Common.Handlers;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Application.LevelManagement.Queries.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.LevelManagement.Queries.GetAllLevelManagement
{
    public class GetAllLevelManagementQueryHandler :
        HandlerQueryBase<GetAllLevelManagementQuery, LevelManagementDto[]>
    {
        public GetAllLevelManagementQueryHandler(IAppDbContext appDbContext, IMapper mapper)
            : base(appDbContext, mapper)
        {
        }

        public override async Task<LevelManagementDto[]> Handle(GetAllLevelManagementQuery request,
            CancellationToken cancellationToken)
        {
            var models = await ContextDb
                .Set<Domain.AggregatesModel.LeveManagement.Entities.LevelManagement>()
                .Include(x=>x.ActiveStatus)
                .ToArrayAsync(cancellationToken);

            return AutoMapper.Map<LevelManagementDto[]>(models);
        }
    }
}
