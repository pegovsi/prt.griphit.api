using Prt.Graphit.Domain.Common;
using Prt.Graphit.Domain.Enumerations;
using System;

namespace Prt.Graphit.Domain.AggregatesModel.KVTMO.Entities
{
    /// <summary>
    /// Классификатор вооружения военной, специальной техники
    /// и военно-технического имущества Министерства обороны Российской Федерации
    /// </summary>
    public class KVTMO : Entity, IAggregateRoot
    {
        protected KVTMO() { }

        public KVTMO(string name, string codeKVTMO)
            : base()
        {
            Id = Guid.NewGuid();
            Name = name;
            CodeKVTMO = codeKVTMO;
            _activeStatusId = ActiveStatus.Draft.Id;
        }

        public override Guid Id { get; protected set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Код КВТ МО
        /// </summary>
        public string CodeKVTMO { get; private set; }

        private int _activeStatusId;
        public ActiveStatus ActiveStatus { get; private set; }

        public void SetActiveStatus(ActiveStatus activeStatus)
        {
            _activeStatusId = activeStatus.Id;
        }
    }
}
