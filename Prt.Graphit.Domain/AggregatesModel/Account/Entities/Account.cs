using Prt.Graphit.Domain.Common;

namespace Prt.Graphit.Domain.AggregatesModel.Account.Entities
{
    public class Account : Entity, IAggregateRoot
    {
        protected Account()
        {
        }

        public Account(string login, string firstName, string lastName, string middleName, string password, bool isConfirm)
        {
            Login = login;
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            Password = password;
            IsConfirm = isConfirm;
        }
        public Account(string login, string email, string firstName, string lastName, string middleName, string password, bool isConfirm)
        {
            Login = login;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            Password = password;
            IsConfirm = isConfirm;
        }

        public string Login { get; private set; }
        public string Email { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string MiddleName { get; private set; }
        public string Password { get; private set; }
        public bool IsConfirm { get; private set; }

    }
}