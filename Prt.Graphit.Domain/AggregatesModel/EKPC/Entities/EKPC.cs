using Prt.Graphit.Domain.Common;
using Prt.Graphit.Domain.Enumerations;
using System;

namespace Prt.Graphit.Domain.AggregatesModel.EKPC.Entities
{
    /// <summary>
    /// Единый кодификатор предметов снабжения
    /// </summary>
    public class EKPC : Entity, IAggregateRoot
    {
        protected EKPC() { }

        public EKPC(string name, string codeEKPC, Guid? parentId = null)
            : base()
        {
            Id = Guid.NewGuid();
            Name = name;
            CodeEKPC = codeEKPC;
            ParentId = parentId;
            _activeStatusId = ActiveStatus.Draft.Id;
        }

        public override Guid Id { get; protected set; }
        /// <summary>
        /// Родитель
        /// </summary>
        public Guid? ParentId { get; private set; }
        public EKPC EKPCParent { get; private set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Код ЕКПС
        /// </summary>
        public string CodeEKPC { get; private set; }

        private int _activeStatusId;
        public ActiveStatus ActiveStatus { get; private set; }

        public void SetActiveStatus(ActiveStatus activeStatus)
        {
            _activeStatusId = activeStatus.Id;
        }
    }
}
