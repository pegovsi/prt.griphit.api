using System;

namespace Prt.Graphit.Application.Subdivision.Queries.Models
{
    public class SubdivisionDto
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Guid? BrigadeId { get; private set; }
    }
}
