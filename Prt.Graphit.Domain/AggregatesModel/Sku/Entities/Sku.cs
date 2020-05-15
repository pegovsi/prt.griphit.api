using Prt.Graphit.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Prt.Graphit.Domain.AggregatesModel.Sku.Entities
{
    public class Sku : Entity, IAggregateRoot
    {
        protected Sku()
        {
            _units = new List<Unit>();
            _skuPictures = new List<SkuPicture>();
        }

        private List<Unit> _units;
        private List<SkuPicture> _skuPictures;

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
        public Sku(string name, Guid? parentId, Guid? skuGroupId, Guid skuTypeId, string designation, string description)
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
            Designation = designation;
            Description = description;
        }
        public Sku(Guid id, string name, Guid? parentId, Guid? skuGroupId, Guid skuTypeId, string designation, string description)
            : this()
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException($"Незаполнено обязательное поле {nameof(name)}");

            if (skuTypeId == Guid.Empty)
                throw new ArgumentNullException($"Незаполнено обязательное поле {nameof(skuTypeId)}");

            if (ParentId == Guid.Empty)
                throw new ArgumentNullException($"Незаполнено обязательное поле {nameof(ParentId)}");

            Id = id;
            Name = name;
            ParentId = parentId;
            SkuTypeId = skuTypeId;
            SkuGroupId = skuGroupId;
            Designation = designation;
            Description = description;
        }

        public override Guid Id { get; protected set; }
        public Guid? ParentId { get; private set; }
        public Sku ParentSku { get; private set; }
        public Guid? SkuGroupId { get; private set; }
        public SkuGroup SkuGroup { get; private set; }
        public string Name { get; private set; }
        public IReadOnlyCollection<Unit> Units => _units;
        public IReadOnlyCollection<SkuPicture> SkuPictures => _skuPictures;
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

        public void AddPicture(string link)
        {
            _skuPictures.Add(new SkuPicture(Id, link));
        }
        public void AddPicture(IEnumerable<string> links)
        {
            _skuPictures.AddRange(links.Select(link => new SkuPicture(Id, link)));
        }

        public void DeletePicture(string link)
        {
            var picture = _skuPictures.FirstOrDefault(x => x.Link == link);
            if (picture != null)
            {
                _skuPictures.Remove(picture);
            }
        }

        public void Delete() => SetDeleted();
        #endregion

        #region DomainEvents

        #endregion
    }
}
