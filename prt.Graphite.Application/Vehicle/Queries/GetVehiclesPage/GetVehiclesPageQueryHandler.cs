using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Prt.Graphit.Application.Common.Extensions;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Application.Common.Paging;
using Prt.Graphit.Application.Vehicle.Queries.Models;

namespace Prt.Graphit.Application.Vehicle.Queries.GetVehiclesPage
{
    public class GetVehiclesPageQueryHandler : PagingQueryHandler<GetVehiclesPageQuery, VehiclesCollectionViewModel, VehicleDto>
    {
        public GetVehiclesPageQueryHandler(IAppDbContext applicationDbContext, IMapper mapper) 
            : base(applicationDbContext, mapper)
        {
        }

        public override async Task<VehiclesCollectionViewModel> Handle(GetVehiclesPageQuery request, CancellationToken cancellationToken)
        {
            var models = ContextDb.Set<Domain.AggregatesModel.Vehicle.Entities.Vehicle>()
                .Where(BuildFilter(request))
                .Include(x => x.VehicleType)
                .Include(x => x.Chassis)
                .Include(x => x.VehicleModel)
                .Include(x => x.Manufacturer)
                .Include(x => x.Garrison)
                .Include(x => x.City)
                .Include(x => x.Division)
                .Include(x => x.Subdivision)
                .Include(x => x.Brigade)
                .Include(x => x.Condition);

            var (list, count) = models.ApplySorting(request.Context);

            var resultList = new VehiclesCollectionViewModel
            {
                Data = AutoMapper.Map<List<VehicleDto>>(await list.ToListAsync(cancellationToken)),
                TotalCount =  count
            };
            return resultList;
        }
        
        private Expression<Func<Domain.AggregatesModel.Vehicle.Entities.Vehicle, bool>> BuildFilter(GetVehiclesPageQuery request)
        {
            var predicate = PredicateBuilder.True<Domain.AggregatesModel.Vehicle.Entities.Vehicle>();
            if (request.Context.Filter.VehicleId.HasValue)
            {
                predicate = predicate.And(x => x.Id == request.Context.Filter.VehicleId);
            }

            if (request.Context.Filter.VehicleName != null)
            {
                predicate = predicate.And(x => x.Name.Contains(request.Context.Filter.VehicleName));
            }
            if (request.Context.Filter.City.HasValue)
            {
                predicate = predicate.And(x => x.CityId == request.Context.Filter.City);
            }
            if (request.Context.Filter.Garrison.HasValue)
            {
                predicate = predicate.And(x => x.GarrisonId == request.Context.Filter.Garrison);
            }
            if (request.Context.Filter.Division.HasValue)
            {
                predicate = predicate.And(x => x.DivisionId == request.Context.Filter.Division);
            }
            if (request.Context.Filter.Subdivision.HasValue)
            {
                predicate = predicate.And(x => x.SubdivisionId == request.Context.Filter.Subdivision);
            }

            return predicate;
        }
    }
}