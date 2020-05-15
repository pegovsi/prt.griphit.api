using Prt.Graphit.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prt.Graphit.Domain.AggregatesModel.Vehicle.Entities
{
    public class Manufacturer : Entity
    {
        protected Manufacturer() { }

        public Manufacturer(string name)
           : this()
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException($"Незаполнено обязательное поле {nameof(name)}");

            Id = Guid.NewGuid();
            Name = name;
        }

        public Manufacturer(Guid id, string name)
            : this()
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException($"Незаполнено обязательное поле {nameof(name)}");

            Id = id;
            Name = name;
        }

        public override Guid Id { get; protected set; }
        public string Name { get; private set; }
    }
}
