using Prt.Graphit.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prt.Graphit.Domain.AggregatesModel.Sku.Entities
{
    public class SkuType : Entity, IAggregateRoot
    {
        protected SkuType() { }

        public SkuType(string name):this()
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException($"Незаполнено обязательное поле {nameof(name)}");

            Id = Guid.NewGuid();
            Name = name;
        }

        public override Guid Id { get; protected set; }
        public string Name { get; private set; }

        public void Delete() => SetDeleted();
    }
}
