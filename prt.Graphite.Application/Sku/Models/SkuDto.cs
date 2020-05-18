using System;
using System.Collections.Generic;
using System.Text;

namespace Prt.Graphit.Application.Sku.Models
{
    public class SkuDto
    {
        public Guid Id { get; private set; }
        public Guid? ParentId { get; private set; }
        public SkuDto ParentSku { get; private set; }
        public SkuGroupDto SkuGroup { get; private set; }
        public string Name { get; private set; }
        public UnitDto[] Units { get; private set; }
        public string Designation { get; private set; }
        public Guid SkuTypeId { get; private set; }
        public SkuTypeDto SkuType { get; private set; }
        public string Description { get; private set; }

    }
}
