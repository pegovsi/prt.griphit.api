using Prt.Graphit.Domain.Common;
using System;
using System.Collections.Generic;

namespace Prt.Graphit.Domain.AggregatesModel.Sku.Entities
{
    public class Sku : Entity, IAggregateRoot
    {
        protected Sku()
        {
            _units = new List<Unit>();
        }

        private List<Unit> _units;
        public Sku(string name, Guid skuTypeId, string description)
            : this()
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException($"Незаполнено обязательное поле {nameof(name)}");

            if (skuTypeId == Guid.Empty)
                throw new ArgumentNullException($"Незаполнено обязательное поле {nameof(skuTypeId)}");

            Id = Guid.NewGuid();
            Name = name;

            SkuTypeId = skuTypeId;
            Description = description;
        }
        public Sku(string name, Guid? parentId, Guid? skuGroupId, Guid skuTypeId, string description)
            : this()
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException($"Незаполнено обязательное поле {nameof(name)}");

            if (skuTypeId == Guid.Empty)
                throw new ArgumentNullException($"Незаполнено обязательное поле {nameof(skuTypeId)}");

            if (ParentId == Guid.Empty)
                throw new ArgumentNullException($"Незаполнено обязательное поле {nameof(ParentId)}");

            Id = Guid.NewGuid();
            Name = name;
            ParentId = parentId;
            SkuTypeId = skuTypeId;
            SkuGroupId = skuGroupId;
            Description = description;
        }

        public override Guid Id { get; protected set; }
        public Guid? ParentId { get; private set; }
        public Sku ParentSku { get; private set; }
        public Guid? SkuGroupId { get; private set; }
        public SkuGroup SkuGroup { get; private set; }
        public string Name { get; private set; }
        public IReadOnlyCollection<Unit> Units => _units;
        public string Designation { get; private set; }
        public Guid SkuTypeId { get; private set; }
        public SkuType SkuType { get; private set; }
        public string Description { get; private set; }

        #region Logic
        public void AddUnit(string name, decimal coefficent, bool @base = false)
        {
            var unitNew = new Unit(name, Id, coefficent, @base);
            _units.Add(unitNew);
        }
        public void Delete() => SetDeleted();
        #endregion

        #region DomainEvents

        #endregion
    }
}
