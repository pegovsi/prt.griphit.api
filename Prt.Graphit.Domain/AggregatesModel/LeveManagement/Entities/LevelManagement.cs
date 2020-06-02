using Prt.Graphit.Domain.Common;
using Prt.Graphit.Domain.Enumerations;
using System;

namespace Prt.Graphit.Domain.AggregatesModel.LeveManagement.Entities
{
    /// <summary>
    /// Уровни управления
    /// </summary>
    public class LevelManagement : Entity, IAggregateRoot
    {
        protected LevelManagement() { }

        public LevelManagement(string name, string code)
            : base()
        {
            Id = Guid.NewGuid();
            Name = name;
            Code = code;

            _activeStatusId = ActiveStatus.Draft.Id;
        }
        public LevelManagement(string name, string code, bool isVch, bool independent)
            : base()
        {
            Id = Guid.NewGuid();
            Name = name;
            Code = code;
            IsVCH = isVch;
            Independent = independent;

            _activeStatusId = ActiveStatus.Draft.Id;
        }

        public override Guid Id { get; protected set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Код
        /// </summary>
        public string Code { get; private set; }

        /// <summary>
        /// Является в/ч
        /// </summary>
        public bool IsVCH { get; private set; }
        /// <summary>
        /// Самостоятельный
        /// </summary>
        public bool Independent { get; private set; }

        private int _activeStatusId;
        public ActiveStatus ActiveStatus { get; private set; }

        public void SetActiveStatus(ActiveStatus activeStatus)
        {
            _activeStatusId = activeStatus.Id;
        }
    }
}
