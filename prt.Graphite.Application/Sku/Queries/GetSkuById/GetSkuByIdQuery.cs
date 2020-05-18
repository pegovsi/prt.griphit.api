using MediatR;
using Prt.Graphit.Application.Sku.Models;
using System;

namespace Prt.Graphit.Application.Sku.Queries
{
    public class GetSkuByIdQuery : IRequest<SkuDto>
    {
        public Guid SkuId { get; }

        public GetSkuByIdQuery(Guid skuId)
        {
            SkuId = skuId;
        }
    }
}
