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
using Prt.Graphit.Application.Users.Queries.Models;



namespace Prt.Graphit.Application.Users.Queries.GetUsersPage
{
    public class GetUsersPageQueryHandler : PagingQueryHandler<GetUsersPageQuery, UserCollectionViewModel, UserDto>
    {
        public GetUsersPageQueryHandler(IAppDbContext applicationDbContext, IMapper mapper)
            : base(applicationDbContext, mapper)
        {
        }

        public override async Task<UserCollectionViewModel> Handle(GetUsersPageQuery request, CancellationToken cancellationToken)
        {
            var models = ContextDb.Set<Domain.AggregatesModel.Account.Entities.Account>()
                .Where(BuildFilter(request));

            var (list, count) = models.ApplySorting(request.Context);

            var resultList = new UserCollectionViewModel
            {
                Data = AutoMapper.Map<List<UserDto>>(await list.ToListAsync(cancellationToken)),
                TotalCount =  count
            };
            return resultList;
        }
        
        private Expression<Func<Domain.AggregatesModel.Account.Entities.Account, bool>> BuildFilter(GetUsersPageQuery request)
        {
            var predicate = PredicateBuilder.True<Domain.AggregatesModel.Account.Entities.Account>();
            if (request.Context.Filter.UserId.HasValue)
            {
                predicate = predicate.And(x => x.Id == request.Context.Filter.UserId);
            }

            if (request.Context.Filter.FirstName != null)
            {
                predicate = predicate.And(x => x.FirstName.Contains(request.Context.Filter.FirstName));
            }
            if (request.Context.Filter.LastName != null)
            {
                predicate = predicate.And(x => x.LastName.Contains(request.Context.Filter.LastName));
            }
            if (request.Context.Filter.MiddleName != null)
            {
                predicate = predicate.And(x => x.MiddleName.Contains(request.Context.Filter.MiddleName));
            }
            return predicate;
        }
    }
}