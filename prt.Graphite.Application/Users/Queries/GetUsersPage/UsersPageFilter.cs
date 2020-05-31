using System;

namespace Prt.Graphit.Application.Users.Queries.GetUsersPage
{
    public class UsersPageFilter
    {
        public Guid? UserId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string MiddleName { get; }
    }
}