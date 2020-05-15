using Prt.Graphit.Domain.Common;
using System;

namespace Prt.Graphit.Domain.AggregatesModel.Sku.Entities
{
    public class SkuGroup : Entity
    {
        protected SkuGroup() { }

        public SkuGroup(string name) : this()
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException($"Незаполнено обязательное поле {nameof(name)}");

            Id = Guid.NewGuid();
            Name = name;
        }
        public SkuGroup(string name, Guid? parentId) : this()
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException($"Незаполнено обязательное поле {nameof(name)}");

            if (ParentId == Guid.Empty)
                throw new ArgumentNullException($"Незаполнено обязательное поле {nameof(ParentId)}");

            Id = Guid.NewGuid();
            Name = name;
            ParentId = parentId;
        }
        public SkuGroup(Guid id, string name, Guid? parentId) : this()
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException($"Незаполнено обязательное поле {nameof(name)}");

            if (ParentId == Guid.Empty)
                throw new ArgumentNullException($"Незаполнено обязательное поле {nameof(ParentId)}");

            Id = id;
            Name = name;
            ParentId = parentId;
        }

        public override Guid Id { get; protected set; }
        public Guid? ParentId { get; protected set; }
        public SkuGroup ParentSkuGroup { get; protected set; }
        public string Name { get; private set; }

        public void Delete() => SetDeleted();
    }
}
