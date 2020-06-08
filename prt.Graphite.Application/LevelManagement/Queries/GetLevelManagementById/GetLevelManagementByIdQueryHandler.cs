using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Prt.Graphit.Application.Common.Handlers;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Application.LevelManagement.Queries.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.LevelManagement.Queries.GetLevelManagementById
{
    public class GetLevelManagementByIdQueryHandler : HandlerQueryBase<GetLevelManagementByIdQuery, LevelManagementDto>
    {
        public GetLevelManagementByIdQueryHandler(IAppDbContext appDbContext, IMapper mapper)
            : base(appDbContext, mapper)
        {
        }

        public override async Task<LevelManagementDto> Handle(GetLevelManagementByIdQuery request,
            CancellationToken cancellationToken)
        {
            var model = await ContextDb
               .Set<Domain.AggregatesModel.LeveManagement.Entities.LevelManagement>()
               .Include(x => x.ActiveStatus)
               .FirstOrDefaultAsync(x => x.Id == request.LevelManagementId, cancellationToken);

            return AutoMapper.Map<LevelManagementDto>(model);
        }
    }
}
