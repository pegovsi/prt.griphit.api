using System;
using System.Collections.Generic;
using System.Text;

namespace Prt.Graphit.Application.Brigade.Queries.Models
{
    public class BrigadeDto
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Guid? DivisionId { get; private set; }
    }
}
