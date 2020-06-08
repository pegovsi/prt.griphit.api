using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Prt.Graphit.Application.Common.Handlers;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Application.MilitaryPosition.Queries.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.MilitaryPosition.Queries.GetAllMilitaryPosition
{
    public class GetAllMilitaryPositionQueryHandler : HandlerQueryBase<GetAllMilitaryPositionQuery, MilitaryPositionDto[]>
    {
        public GetAllMilitaryPositionQueryHandler(IAppDbContext appDbContext, IMapper mapper)
            : base(appDbContext, mapper)
        {
        }

        public override async Task<MilitaryPositionDto[]> Handle(GetAllMilitaryPositionQuery request,
            CancellationToken cancellationToken)
        {
            var models = await ContextDb.Set<Domain.AggregatesModel.MilitaryPosition.Entities.MilitaryPosition>()
                .Include(x => x.ActiveStatus)
                .Include(x => x.TypeStateServiceStatus)
                .ToArrayAsync(cancellationToken);

            return AutoMapper.Map<MilitaryPositionDto[]>(models);
        }
    }
}
