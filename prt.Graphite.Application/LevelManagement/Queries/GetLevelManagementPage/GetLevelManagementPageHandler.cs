using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Prt.Graphit.Application.Common.Extensions;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Application.Common.Paging;
using Prt.Graphit.Application.LevelManagement.Queries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.LevelManagement.Queries.GetLevelManagementPage
{
    public class GetLevelManagementPageHandler
        : PagingQueryHandler<GetLevelManagementPage, LevelManagementCollectionViewModel, LevelManagementDto>
    {
        public GetLevelManagementPageHandler(IAppDbContext applicationDbContext, IMapper mapper)
            : base(applicationDbContext, mapper)
        {
        }

        public override async Task<LevelManagementCollectionViewModel> Handle(GetLevelManagementPage request,
            CancellationToken cancellationToken)
        {
            var models = ContextDb
               .Set<Domain.AggregatesModel.LeveManagement.Entities.LevelManagement>()
               .Where(BuildFilter(request))
               .Include(x => x.ActiveStatus);

            var (list, count) = models.ApplySorting(request.Context);

            var resultList = new LevelManagementCollectionViewModel
            {
                Data = AutoMapper.Map<List<LevelManagementDto>>(await list.ToListAsync(cancellationToken)),
                TotalCount = count
            };
            return resultList;
        }
        private Expression<Func<Domain.AggregatesModel.LeveManagement.Entities.LevelManagement, bool>> BuildFilter(GetLevelManagementPage request)
        {
            var predicate = PredicateBuilder.True<Domain.AggregatesModel.LeveManagement.Entities.LevelManagement>();
            if (request.Context.Filter.LevelManagementId.HasValue)
            {
                predicate = predicate.And(x => x.Id == request.Context.Filter.LevelManagementId);
            }
            return predicate;
        }
    }
}
