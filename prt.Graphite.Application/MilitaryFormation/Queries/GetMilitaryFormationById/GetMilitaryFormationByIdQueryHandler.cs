using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Prt.Graphit.Application.Common.Handlers;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Application.MilitaryFormation.Queries.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.MilitaryFormation.Queries.GetMilitaryFormationById
{
    public class GetMilitaryFormationByIdQueryHandler : HandlerQueryBase<GetMilitaryFormationByIdQuery, MilitaryFormationDto>
    {
        public GetMilitaryFormationByIdQueryHandler(IAppDbContext appDbContext, IMapper mapper)
            : base(appDbContext, mapper)
        {
        }

        public override async Task<MilitaryFormationDto> Handle(GetMilitaryFormationByIdQuery request,
            CancellationToken cancellationToken)
        {
            var model = await ContextDb.Set<Domain.AggregatesModel.MilitaryFormation.Entities.MilitaryFormation>()
                .Include(x => x.ActiveStatus)
                .Include(x => x.LevelManagement)
                .FirstOrDefaultAsync(x => x.Id == request.MilitaryFormationId, cancellationToken);

            return AutoMapper.Map<MilitaryFormationDto>(model);
        }
    }
}
