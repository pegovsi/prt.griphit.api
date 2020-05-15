using Prt.Graphit.Domain.Common;
using System;

namespace Prt.Graphit.Domain.AggregatesModel.Sku.Entities
{
    public class Unit : Entity
    {
        protected Unit() { }

        public Unit(string name, Guid skuId, decimal coefficient, bool @base = false) : this()
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException($"Незаполнено обязательное поле {nameof(name)}");

            if (skuId == Guid.Empty)
                throw new ArgumentNullException($"Незаполнено обязательное поле {nameof(skuId)}");

            Id = Guid.NewGuid();
            Name = name;
            SkuId = skuId;
            Base = @base;

            if (coefficient == default)
                Coefficient = 1;
            else
                Coefficient = coefficient;
        }
        public Unit(Guid id, string name, Guid skuId, decimal coefficient, bool @base = false) : this()
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException($"Незаполнено обязательное поле {nameof(name)}");

            if (skuId == Guid.Empty)
                throw new ArgumentNullException($"Незаполнено обязательное поле {nameof(skuId)}");

            Id = id;
            Name = name;
            SkuId = skuId;
            Base = @base;

            if (coefficient == default)
                Coefficient = 1;
            else
                Coefficient = coefficient;
        }

        public override Guid Id { get; protected set; }
        public string Name { get; private set; }
        public Guid SkuId { get; private set; }
        public Sku Sku { get; private set; }
        public decimal Coefficient { get; private set; }
        public bool Base { get; private set; }

        public void Delete() => SetDeleted();
    }
}
