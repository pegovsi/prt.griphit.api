using System;
using System.Collections.Generic;
using System.Text;

namespace Prt.Graphit.Application.Sku.Models
{
    public class SkuGroupDto
    {
        public Guid Id { get; private set; }
        public Guid? ParentId { get; private set; }
        public string Name { get; private set; }
    }
}
