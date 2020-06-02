using Prt.Graphit.Domain.AggregatesModel.LeveManagement.Entities;
using Prt.Graphit.Domain.Common;
using Prt.Graphit.Domain.Enumerations;
using System;

namespace Prt.Graphit.Domain.AggregatesModel.MilitaryFormation.Entities
{
    /// <summary>
    /// Воинское формирование
    /// </summary>
    public class MilitaryFormation : Entity, IAggregateRoot
    {
        protected MilitaryFormation() { }

        public MilitaryFormation(string name, string shortName, string militaryNameUnit)
            : base()
        {
            Id = Guid.NewGuid();
            Name = name;
            ShortName = shortName;
            MilitaryNameUnit = militaryNameUnit;
            _activeStatusId = ActiveStatus.Draft.Id;
        }
        public MilitaryFormation(string name, string shortName, string militaryNameUnit, Guid? parentId, Guid? levelManagementId)
            : base()
        {
            Id = Guid.NewGuid();
            Name = name;
            ShortName = shortName;
            MilitaryNameUnit = militaryNameUnit;
            ParentId = parentId;
            LevelManagementId = levelManagementId;

            _activeStatusId = ActiveStatus.Draft.Id;
        }

        public override Guid Id { get; protected set; }
        public Guid? ParentId { get; protected set; }
        public MilitaryFormation Parent { get; private set; }
        public string Name { get; private set; }
        public string ShortName { get; private set; }

        /// <summary>
        /// Уровни управления
        /// </summary>
        public Guid? LevelManagementId { get; private set; }
        public LevelManagement LevelManagement { get; private set; }
        /// <summary>
        /// Наименование воинской части
        /// </summary>
        public string MilitaryNameUnit { get; private set; }

        private int _activeStatusId;
        public ActiveStatus ActiveStatus { get; private set; }

        public void SetActiveStatus(ActiveStatus activeStatus)
        {
            _activeStatusId = activeStatus.Id;
        }
    }
}
