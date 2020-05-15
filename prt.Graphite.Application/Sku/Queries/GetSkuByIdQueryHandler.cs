using MediatR;
using Microsoft.EntityFrameworkCore;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Application.Sku.Models;
using Prt.Graphit.Domain.AggregatesModel.Sku.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.Sku.Queries
{
    public class GetSkuByIdQueryHandler : IRequestHandler<GetSkuByIdQuery, SkuDto>
    {
        private readonly ISkuDbContext _skuDbContext;

        public GetSkuByIdQueryHandler(ISkuDbContext skuDbContext)
        {
            _skuDbContext = skuDbContext;
        }

        public async Task<SkuDto> Handle(GetSkuByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _skuDbContext.Set<Domain.AggregatesModel.Sku.Entities.Sku>()
                .FirstOrDefaultAsync(x=>x.Id == request.SkuId);

            return new SkuDto();
        }
    }
}
