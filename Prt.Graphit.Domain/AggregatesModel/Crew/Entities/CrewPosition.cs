using Prt.Graphit.Domain.Common;
using System;

namespace Prt.Graphit.Domain.AggregatesModel.Crew.Entities
{
    public class CrewPosition : Entity
    {
        protected CrewPosition() { }

        public CrewPosition(Guid militaryPositionId, Guid? accountId)
            : base()
        {
            Id = Guid.NewGuid();
            MilitaryPositionId = militaryPositionId;
            AccountId = accountId;
        }
        public override Guid Id { get; protected set; }
        public Guid MilitaryPositionId { get; private set; }
        public MilitaryPosition.Entities.MilitaryPosition MilitaryPosition { get; private set; }
        public Guid? AccountId { get; private set; }
        public Account.Entities.Account Account { get; private set; }

        public void SetAccount(Guid accountId)
        {
            this.AccountId = accountId;
        }
    }
}
