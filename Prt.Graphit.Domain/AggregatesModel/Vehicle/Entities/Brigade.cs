using Prt.Graphit.Domain.Common;
using System;

namespace Prt.Graphit.Domain.AggregatesModel.Vehicle.Entities
{
    public class Brigade : Entity
    {
        protected Brigade() { }

        public Brigade(string name)
          : this()
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException($"Незаполнено обязательное поле {nameof(name)}");

            Id = Guid.NewGuid();
            Name = name;
        }

        public Brigade(Guid id, string name)
            : this()
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException($"Незаполнено обязательное поле {nameof(name)}");

            Id = id;
            Name = name;
        }
        public Brigade(Guid id, string name, Guid? divisionId)
            : this()
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException($"Незаполнено обязательное поле {nameof(name)}");

            Id = id;
            Name = name;
            DivisionId = divisionId;
        }
        public override Guid Id { get; protected set; }
        public string Name { get; private set; }
        public Guid? DivisionId { get; private set; }
    }
}
