using System;

namespace Prt.Graphit.Application.Sku.Models
{
    public class UnitDto
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public decimal Coefficient { get; private set; }
        public bool Base { get; private set; }
    }
}
