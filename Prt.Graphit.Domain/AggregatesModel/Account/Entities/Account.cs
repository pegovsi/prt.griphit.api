using Prt.Graphit.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Prt.Graphit.Domain.AggregatesModel.Account.Entities
{
    public class Account : Entity, IAggregateRoot
    {
        protected Account()
        {
            _accountMilitaryPositions = new List<AccountMilitaryPosition>();
        }

        public Account(string login, string firstName, string lastName, string middleName, string password, bool isConfirm)
        {
            Id = Guid.NewGuid();
            Login = login;
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            Password = password;
            IsConfirm = isConfirm;
        }
        public Account(string login, string email, string firstName, string lastName,
            string middleName, string password, bool isConfirm,
            Guid? militaryRankId, Guid? militaryFormationId)
        {
            Id = Guid.NewGuid();
            Login = login;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            Password = password;
            IsConfirm = isConfirm;
            MilitaryRankId = militaryRankId;
            MilitaryFormationId = militaryFormationId;
        }

        public string Login { get; private set; }
        public string Email { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string MiddleName { get; private set; }
        public string Password { get; private set; }
        public bool IsConfirm { get; private set; }
        public Guid? MilitaryRankId { get; private set; }
        public MilitaryRank.Entities.MilitaryRank MilitaryRank { get; private set; }
        public Guid? MilitaryFormationId { get; private set; }
        public MilitaryFormation.Entities.MilitaryFormation MilitaryFormation { get; private set; }

        private List<AccountMilitaryPosition> _accountMilitaryPositions;
        public IReadOnlyCollection<AccountMilitaryPosition> AccountMilitaryPositions 
            => _accountMilitaryPositions;

        public void SetMilitaryRank(Guid militaryRankId)
        {
            MilitaryRankId = militaryRankId;
        }

        public void SetMilitaryFormation(Guid militaryFormationId)
        {
            MilitaryFormationId = militaryFormationId;
        }

        public void AddMilitaryPosition(Guid militaryPositionId)
        {
            var position = _accountMilitaryPositions
                .FirstOrDefault(x => x.MilitaryPositionId == militaryPositionId);

            if (position is null)
                _accountMilitaryPositions.Add(new AccountMilitaryPosition(this.Id, militaryPositionId));
        }

        public void RemoveMilitaryPosition(Guid militaryPositionId)
        {
            var position = _accountMilitaryPositions
                .FirstOrDefault(x => x.MilitaryPositionId == militaryPositionId);

            if (position is null)
                return;

            _accountMilitaryPositions.Remove(new AccountMilitaryPosition(this.Id, militaryPositionId));
        }
    }
}