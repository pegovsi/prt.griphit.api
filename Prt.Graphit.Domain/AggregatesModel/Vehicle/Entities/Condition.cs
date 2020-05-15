using Prt.Graphit.Domain.Common;
using System;

namespace Prt.Graphit.Domain.AggregatesModel.Vehicle.Entities
{
    public class Condition : Entity
    {
        protected Condition() { }

        public Condition(string name)
          : this()
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException($"Незаполнено обязательное поле {nameof(name)}");

            Id = Guid.NewGuid();
            Name = name;
        }      
        public Condition(string name, string iconLink, bool readiness)
            : this()
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException($"Незаполнено обязательное поле {nameof(name)}");

            Id = Guid.NewGuid();
            Name = name;
            IconLink = iconLink;
            Readiness = readiness;
        }
        public override Guid Id { get; protected set; }
        public string Name { get; private set; }
        public string IconLink { get; private set; }
        public bool Readiness { get; private set; }
    }
}
