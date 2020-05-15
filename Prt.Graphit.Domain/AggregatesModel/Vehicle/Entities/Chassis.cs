using Prt.Graphit.Domain.Common;
using System;

namespace Prt.Graphit.Domain.AggregatesModel.Vehicle.Entities
{
    public class Chassis : Entity
    {
        protected Chassis() { }

        public Chassis(string name)
            : this()
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException($"Незаполнено обязательное поле {nameof(name)}");

            Id = Guid.NewGuid();
            Name = name;
        }

        public Chassis(Guid id, string name)
            : this()
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException($"Незаполнено обязательное поле {nameof(name)}");

            Id = id;
            Name = name;
        }
        public Chassis(Guid id, string name, Guid manufacturerId)
            : this()
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException($"Незаполнено обязательное поле {nameof(name)}");

            Id = id;
            Name = name;
            ManufacturerId = manufacturerId;
        }

        public override Guid Id { get; protected set; }
        public string Name { get; private set; }
        public Guid? ManufacturerId { get; private set; }
    }
}
