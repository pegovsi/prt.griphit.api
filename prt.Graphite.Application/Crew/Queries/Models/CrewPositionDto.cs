using Prt.Graphit.Application.MilitaryPosition.Queries.Models;
using Prt.Graphit.Application.Users.Queries.Models;
using System;

namespace Prt.Graphit.Application.Crew.Queries.Models
{
    public class CrewPositionDto
    {
        public Guid Id { get; private set; }
        public Guid MilitaryPositionId { get; private set; }
        public MilitaryPositionDto MilitaryPosition { get; private set; }
        public Guid? AccountId { get; private set; }
        public UserDto Account { get; private set; }
    }
}
