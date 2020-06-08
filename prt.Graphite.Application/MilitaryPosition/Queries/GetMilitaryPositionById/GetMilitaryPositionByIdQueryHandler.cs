using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Prt.Graphit.Application.Common.Handlers;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Application.MilitaryPosition.Queries.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.MilitaryPosition.Queries.GetMilitaryPositionById
{
    public class GetMilitaryPositionByIdQueryHandler
        : HandlerQueryBase<GetMilitaryPositionByIdQuery, MilitaryPositionDto>
    {
        public GetMilitaryPositionByIdQueryHandler(IAppDbContext appDbContext, IMapper mapper)
            : base(appDbContext, mapper)
        {
        }

        public override async Task<MilitaryPositionDto> Handle(GetMilitaryPositionByIdQuery request,
            CancellationToken cancellationToken)
        {
            var model = await ContextDb
                .Set<Domain.AggregatesModel.MilitaryPosition.Entities.MilitaryPosition>()
                .Include(x => x.ActiveStatus)
                .Include(x => x.TypeStateServiceStatus)
                .FirstOrDefaultAsync(x => x.Id == request.MilitaryPositionId, cancellationToken);

            return AutoMapper.Map<MilitaryPositionDto>(model);
        }
    }
}
