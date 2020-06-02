using Prt.Graphit.Domain.Common;
using System;

namespace Prt.Graphit.Domain.AggregatesModel.TypesMilitaryOrder.Entities
{
    /// <summary>
    /// Вид приказа
    /// </summary>
    public class TypesMilitaryOrder : Entity, IAggregateRoot
    {
        protected TypesMilitaryOrder() { }

        public TypesMilitaryOrder(string name)
            : base()
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public override Guid Id { get; protected set; }

        public string Name { get; private set; }
    }
}
