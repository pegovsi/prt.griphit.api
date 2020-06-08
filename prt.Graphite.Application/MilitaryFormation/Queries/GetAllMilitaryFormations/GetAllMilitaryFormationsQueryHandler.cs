using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Prt.Graphit.Application.Common.Handlers;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Application.MilitaryFormation.Queries.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.MilitaryFormation.Queries.GetAllMilitaryFormations
{
    public class GetAllMilitaryFormationsQueryHandler
        : HandlerQueryBase<GetAllMilitaryFormationsQuery, MilitaryFormationDto[]>
    {
        public GetAllMilitaryFormationsQueryHandler(IAppDbContext appDbContext, IMapper mapper)
            : base(appDbContext, mapper)
        {
        }

        public async override Task<MilitaryFormationDto[]> Handle(GetAllMilitaryFormationsQuery request,
            CancellationToken cancellationToken)
        {
            var models = await ContextDb
                .Set<Domain.AggregatesModel.MilitaryFormation.Entities.MilitaryFormation>()
                .Include(x=>x.ActiveStatus)
                .Include(x => x.LevelManagement)
                .ToArrayAsync(cancellationToken);

            return AutoMapper.Map<MilitaryFormationDto[]>(models);
        }
    }
}
