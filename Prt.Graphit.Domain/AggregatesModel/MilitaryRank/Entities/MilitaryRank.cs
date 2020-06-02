using Prt.Graphit.Domain.Common;
using Prt.Graphit.Domain.Enumerations;
using System;

namespace Prt.Graphit.Domain.AggregatesModel.MilitaryRank.Entities
{
    /// <summary>
    ///  Воинские звания
    /// </summary>
    public class MilitaryRank : Entity, IAggregateRoot
    {
        protected MilitaryRank() { }

        public MilitaryRank(string name, string shortName)
            : base()
        {
            Id = Guid.NewGuid();
            Name = name;
            ShortName = shortName;
            _activeStatusId = ActiveStatus.Draft.Id;
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

        public void SetActiveStatus(ActiveStatus activeStatus)
        {
            _activeStatusId = activeStatus.Id;
        }
    }
}
