using Prt.Graphit.Domain.Common;
using System;

namespace Prt.Graphit.Domain.AggregatesModel.Vehicle.Entities
{
    public class Subdivision : Entity
    {
        protected Subdivision() { }

        public Subdivision(string name)
          : this()
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException($"Незаполнено обязательное поле {nameof(name)}");

            Id = Guid.NewGuid();
            Name = name;
        }

        public Subdivision(Guid id, string name)
            : this()
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException($"Незаполнено обязательное поле {nameof(name)}");

            Id = id;
            Name = name;
        }

        public Subdivision(Guid id, string name, Guid? brigadeId)
            : this()
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException($"Незаполнено обязательное поле {nameof(name)}");

            Id = id;
            Name = name;
            BrigadeId = brigadeId;
        }

        public override Guid Id { get; protected set; }
        public string Name { get; private set; }
        public Guid? BrigadeId { get; private set; }
    }
}
