using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Prt.Graphit.Application.Common.Extensions;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Application.Common.Paging;
using Prt.Graphit.Application.MilitaryFormation.Queries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.MilitaryFormation.Queries.GetMilitaryFormationPage
{
    public class GetMilitaryFormationPageQueryHandler

        : PagingQueryHandler<GetMilitaryFormationPageQuery, MilitaryFormationCollectionViewModel, MilitaryFormationDto>
    {
        public GetMilitaryFormationPageQueryHandler(IAppDbContext applicationDbContext, IMapper mapper)
            : base(applicationDbContext, mapper)
        {
        }

        public override async Task<MilitaryFormationCollectionViewModel> Handle(GetMilitaryFormationPageQuery request,
            CancellationToken cancellationToken)
        {

            var models = ContextDb.Set<Domain.AggregatesModel.MilitaryFormation.Entities.MilitaryFormation>()
                .Where(BuildFilter(request))
               .Include(x => x.ActiveStatus)
               .Include(x => x.LevelManagement);

            var (list, count) = models.ApplySorting(request.Context);

            var resultList = new MilitaryFormationCollectionViewModel
            {
                Data = AutoMapper.Map<List<MilitaryFormationDto>>(await list.ToListAsync(cancellationToken)),
                TotalCount = count
            };
            return resultList;
        }

        private Expression<Func<Domain.AggregatesModel.MilitaryFormation.Entities.MilitaryFormation, bool>> BuildFilter(GetMilitaryFormationPageQuery request)
        {
            var predicate = PredicateBuilder.True<Domain.AggregatesModel.MilitaryFormation.Entities.MilitaryFormation>();
            if (request.Context.Filter.MilitaryFormationId.HasValue)
            {
                predicate = predicate.And(x => x.Id == request.Context.Filter.MilitaryFormationId);
            }
            if (request.Context.Filter.LevelManagementId.HasValue)
            {
                predicate = predicate.And(x => x.LevelManagementId == request.Context.Filter.LevelManagementId);
            }

            return predicate;
        }
    }
}
