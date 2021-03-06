﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Prt.Graphit.Application.Common.Handlers;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Application.Sku.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.Sku.Queries.SearchSkuByName
{
    public class SearchSkuByNameQueryHandler : HandlerQueryBase<SearchSkuByNameQuery, SkuDto[]>
    {
        public SearchSkuByNameQueryHandler(IAppDbContext appDbContext, IMapper mapper) 
            : base(appDbContext, mapper)
        {
        }

        public override async Task<SkuDto[]> Handle(SearchSkuByNameQuery request, CancellationToken cancellationToken)
        {
            var skuArray = await ContextDb.Set<Domain.AggregatesModel.Sku.Entities.Sku>()
                   .Where(x => x.Name.ToLower().Contains(request.SkuNameSearch.ToLower()))
                   .Include(x => x.SkuGroup)
                   .Include(x => x.SkuType)
                   .Include(x => x.Units)
                   .ToArrayAsync(cancellationToken);

            return AutoMapper.Map<SkuDto[]>(skuArray);
        }
    }
}
