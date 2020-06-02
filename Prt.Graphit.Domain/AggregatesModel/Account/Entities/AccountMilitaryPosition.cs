using Prt.Graphit.Domain.Common;
using System;

namespace Prt.Graphit.Domain.AggregatesModel.Account.Entities
{
    /// <summary>
    /// Должности пользователя
    /// </summary>
    public class AccountMilitaryPosition : Entity, IAggregateRoot
    {
        protected AccountMilitaryPosition() { }

        public AccountMilitaryPosition(Guid accountId, Guid militaryPositionId)
            : base()
        {
            AccountId = accountId;
            MilitaryPositionId = militaryPositionId;
        }

        public override Guid Id { get; protected set; }

        public Guid AccountId { get; private set; }
        public Guid MilitaryPositionId { get; private set; }
        public MilitaryPosition.Entities.MilitaryPosition MilitaryPosition { get; private set; }
    }
}
