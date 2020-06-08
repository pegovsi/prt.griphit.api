using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Prt.Graphit.Application.Common.Extensions;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Application.Common.Paging;
using Prt.Graphit.Application.MilitaryPosition.Queries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.MilitaryPosition.Queries.GetMilitaryPositionPage
{
    public class GetMilitaryPositionPageQueryHandler
        : PagingQueryHandler<GetMilitaryPositionPageQuery, MilitaryPositionCollectionViewModel, MilitaryPositionDto>
    {
        public GetMilitaryPositionPageQueryHandler(IAppDbContext applicationDbContext, IMapper mapper)
            : base(applicationDbContext, mapper)
        {
        }

        public override async Task<MilitaryPositionCollectionViewModel> Handle(GetMilitaryPositionPageQuery request, CancellationToken cancellationToken)
        {
            var models = ContextDb.Set<Domain.AggregatesModel.MilitaryPosition.Entities.MilitaryPosition>()
                .Include(x => x.ActiveStatus)
                .Include(x => x.TypeStateServiceStatus)
                .Where(BuildFilter(request));

            var (list, count) = models.ApplySorting(request.Context);

            var resultList = new MilitaryPositionCollectionViewModel
            {
                Data = AutoMapper.Map<List<MilitaryPositionDto>>(await list.ToListAsync(cancellationToken)),
                TotalCount = count
            };
            return resultList;
        }
        private Expression<Func<Domain.AggregatesModel.MilitaryPosition.Entities.MilitaryPosition, bool>> BuildFilter(GetMilitaryPositionPageQuery request)
        {
            var predicate = PredicateBuilder.True<Domain.AggregatesModel.MilitaryPosition.Entities.MilitaryPosition>();
            if (request.Context.Filter.MilitaryPositionId.HasValue)
            {
                predicate = predicate.And(x => x.Id == request.Context.Filter.MilitaryPositionId);
            }

            return predicate;
        }
    }
}
