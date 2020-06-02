using Prt.Graphit.Domain.Common;
using Prt.Graphit.Domain.Enumerations;
using System;

namespace Prt.Graphit.Domain.AggregatesModel.MilitaryPosition.Entities
{
    /// <summary>
    /// Должность
    /// </summary>
    public class MilitaryPosition : Entity, IAggregateRoot
    {
        protected MilitaryPosition() { }

        public MilitaryPosition(string name, string shortName, TypeStateServiceStatus typeStateServiceStatus)
            : base()
        {
            Id = Guid.NewGuid();
            Name = name;
            ShortName = shortName;
            _activeStatusId = ActiveStatus.Draft.Id;
            _typeStateServiceStatusId = typeStateServiceStatus.Id;
        }

        public override Guid Id { get; protected set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Аббревиатура
        /// </summary>
        public string ShortName { get; private set; }

        private int _activeStatusId;
        public ActiveStatus ActiveStatus { get; private set; }

        /// <summary>
        /// Вид государственной службы
        /// </summary>
        private int _typeStateServiceStatusId;
        public TypeStateServiceStatus TypeStateServiceStatus { get; private set; }


        public void SetActiveStatus(ActiveStatus activeStatus)
        {
            _activeStatusId = activeStatus.Id;
        }

        public void SetTypeStateServiceStatus(TypeStateServiceStatus typeStateServiceStatus)
        {
            _typeStateServiceStatusId = typeStateServiceStatus.Id;
        }
    }
}
