using Prt.Graphit.Domain.Common;
using System;

namespace Prt.Graphit.Domain.AggregatesModel.Vehicle.Entities
{
    public class Garrison : Entity
    {
        protected Garrison() { }

        public Garrison(string name)
          : this()
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException($"Незаполнено обязательное поле {nameof(name)}");

            Id = Guid.NewGuid();
            Name = name;
        }

        public Garrison(Guid id, string name)
            : this()
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException($"Незаполнено обязательное поле {nameof(name)}");

            Id = id;
            Name = name;
        }

        public Garrison(Guid id, string name, decimal coordinateX, decimal coordinateY, int rate)
           : this()
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException($"Незаполнено обязательное поле {nameof(name)}");

            Id = id;
            Name = name;
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
            Rate = rate;
        }

        public override Guid Id { get; protected set; }
        public string Name { get; private set; }
        public decimal CoordinateX { get; private set; }
        public decimal CoordinateY { get; private set; }
        public int Rate { get; private set; }
    }
}
