using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Prt.Graphit.Application.Common.Extensions;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Application.Common.Paging;
using Prt.Graphit.Application.UserMasterData.Queries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.UserMasterData.Queries.GetUserMasterDataPage
{
    public class GetUserMasterDataPageQueryHandler :
        PagingQueryHandler<GetUserMasterDataPageQuery, UserMasterDataCollectionViewModel, UserMasterDataDto>
    {
        public GetUserMasterDataPageQueryHandler(IAppDbContext applicationDbContext, IMapper mapper)
            : base(applicationDbContext, mapper)
        {
        }

        public override async Task<UserMasterDataCollectionViewModel> Handle(GetUserMasterDataPageQuery request,
            CancellationToken cancellationToken)
        {
            var models = ContextDb
               .Set<Domain.AggregatesModel.UserMasterData.Entities.UserMasterData>()
               .Where(BuildFilter(request))
               .Include(x=>x.VehicleModel)
               .Include(x => x.UserMasterDataFields)
               .ThenInclude(x => x.TypeUserMasterData);

            var (list, count) = models.ApplySorting(request.Context);

            var resultList = new UserMasterDataCollectionViewModel
            {
                Data = AutoMapper.Map<List<UserMasterDataDto>>(await list.ToListAsync(cancellationToken)),
                TotalCount = count
            };
            return resultList;
        }
        private Expression<Func<Domain.AggregatesModel.UserMasterData.Entities.UserMasterData, bool>> BuildFilter(GetUserMasterDataPageQuery request)
        {
            var predicate = PredicateBuilder.True<Domain.AggregatesModel.UserMasterData.Entities.UserMasterData>();
            if (request.Context.Filter.VehicleModelId.HasValue)
            {
                predicate = predicate.And(x => x.VehicleModelId == request.Context.Filter.VehicleModelId);
            }

            return predicate;
        }
    }
}
