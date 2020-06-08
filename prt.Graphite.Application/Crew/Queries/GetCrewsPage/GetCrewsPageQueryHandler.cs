using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Prt.Graphit.Application.Common.Extensions;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Application.Common.Paging;
using Prt.Graphit.Application.Crew.Queries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.Crew.Queries.GetCrewsPage
{
    public class GetCrewsPageQueryHandler :
        PagingQueryHandler<GetCrewsPageQuery, CrewCollectionViewModel, CrewDto>
    {
        public GetCrewsPageQueryHandler(IAppDbContext applicationDbContext, IMapper mapper)
            : base(applicationDbContext, mapper)
        {
        }

        public override async Task<CrewCollectionViewModel> Handle(GetCrewsPageQuery request, 
            CancellationToken cancellationToken)
        {
            var models = ContextDb.Set<Domain.AggregatesModel.Crew.Entities.Crew>()
                .Where(BuildFilter(request))
                .Include(x => x.CrewPositions).ThenInclude(x => x.MilitaryPosition)
                .Include(x => x.CrewPositions).ThenInclude(x => x.Account)
                .Include(x => x.MilitaryFormation)
                .Include(x => x.TypesMilitaryOrder)
                .Include(x => x.Vehicle);

            var (list, count) = models.ApplySorting(request.Context);

            var resultList = new CrewCollectionViewModel
            {
                Data = AutoMapper.Map<List<CrewDto>>(await list.ToListAsync(cancellationToken)),
                TotalCount = count
            };
            return resultList;
        }
        private Expression<Func<Domain.AggregatesModel.Crew.Entities.Crew, bool>> BuildFilter(GetCrewsPageQuery request)
        {
            var predicate = PredicateBuilder.True<Domain.AggregatesModel.Crew.Entities.Crew>();
            if (request.Context.Filter.VehicleId.HasValue)
            {
                predicate = predicate.And(x => x.Id == request.Context.Filter.VehicleId);
            }           
            if (request.Context.Filter.MilitaryFormationId.HasValue)
            {
                predicate = predicate.And(x => x.MilitaryFormationId == request.Context.Filter.MilitaryFormationId);
            }

            return predicate;
        }
    }
}
