using Prt.Graphit.Domain.Common;
using System;

namespace Prt.Graphit.Domain.AggregatesModel.Sku.Entities
{
    public class SkuPicture : Entity
    {
        protected SkuPicture() { }

        public SkuPicture(Guid skuId, string link)
        {
            Id = Guid.NewGuid();
            SkuId = skuId;
            Link = link;
        }
        public SkuPicture(Guid id, Guid skuId, string link)
        {
            Id = id;
            SkuId = skuId;
            Link = link;
        }

        public override Guid Id { get; protected set; }
        public Guid SkuId { get; private set; }
        public string Link { get; private set; }
    }
}
