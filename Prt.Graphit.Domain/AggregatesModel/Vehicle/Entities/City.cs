using Prt.Graphit.Domain.Common;
using System;

namespace Prt.Graphit.Domain.AggregatesModel.Vehicle.Entities
{
    public class City : Entity
    {
        protected City() { }

        public City(string name)
          : this()
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException($"Незаполнено обязательное поле {nameof(name)}");

            Id = Guid.NewGuid();
            Name = name;
        }

        public City(Guid id, string name)
            : this()
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException($"Незаполнено обязательное поле {nameof(name)}");

            Id = id;
            Name = name;
        }
        public City(Guid id, string name, Guid? garrisonId)
            : this()
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException($"Незаполнено обязательное поле {nameof(name)}");

            Id = id;
            Name = name;
            GarrisonId = garrisonId;
        }

        public override Guid Id { get; protected set; }
        public string Name { get; private set; }
        public Guid? GarrisonId { get; private set; }
    }
}
