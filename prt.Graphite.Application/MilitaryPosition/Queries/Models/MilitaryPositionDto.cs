using Prt.Graphit.Application.ActiveStatus.Models;
using System;

namespace Prt.Graphit.Application.MilitaryPosition.Queries.Models
{
    public class MilitaryPositionDto
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string ShortName { get; private set; }
        public ActiveStatusDto ActiveStatus { get; private set; }
    }
}
