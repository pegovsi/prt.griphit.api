using System;

namespace Prt.Graphit.Application.Users.Queries.Models
{
    public class UserDto
    {
        public Guid Id { get; private set; }
        public string Login { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string MiddleName { get; private set; }
    }
}