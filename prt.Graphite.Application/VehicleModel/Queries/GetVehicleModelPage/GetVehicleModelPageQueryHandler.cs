using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Prt.Graphit.Application.Common.Extensions;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Application.Common.Paging;
using Prt.Graphit.Application.VehicleModel.Queries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.VehicleModel.Queries.GetVehicleModelPage
{
    public class GetVehicleModelPageQueryHandler
        : PagingQueryHandler<GetVehicleModelPageQuery, VehicleModelCollectionViewModel, VehicleModelDto>
    {
        public GetVehicleModelPageQueryHandler(IAppDbContext applicationDbContext, IMapper mapper)
            : base(applicationDbContext, mapper)
        {
        }

        public override async Task<VehicleModelCollectionViewModel> Handle(GetVehicleModelPageQuery request,
            CancellationToken cancellationToken)
        {
            var models = ContextDb.Set<Domain.AggregatesModel.Vehicle.Entities.VehicleModel>()
                 .Where(BuildFilter(request))
                 .Include(x => x.VehicleModelPositions);

            var (list, count) = models.ApplySorting(request.Context);

            var resultList = new VehicleModelCollectionViewModel
            {
                Data = AutoMapper.Map<List<VehicleModelDto>>(await list.ToListAsync(cancellationToken)),
                TotalCount = count
            };
            return resultList;
        }

        private Expression<Func<Domain.AggregatesModel.Vehicle.Entities.VehicleModel, bool>> BuildFilter(GetVehicleModelPageQuery request)
        {
            var predicate = PredicateBuilder.True<Domain.AggregatesModel.Vehicle.Entities.VehicleModel>();
            if (request.Context.Filter.VehicleModelId.HasValue)
            {
                predicate = predicate.And(x => x.Id == request.Context.Filter.VehicleModelId);
            }
            if (request.Context.Filter.VehicleTypeId.HasValue)
            {
                predicate = predicate.And(x => x.VehicleModelTypeId == request.Context.Filter.VehicleTypeId);
            }
            if (request.Context.Filter.ChassisId.HasValue)
            {
                predicate = predicate.And(x => x.ChassiId == request.Context.Filter.ChassisId);
            }

            return predicate;
        }
    }
}
