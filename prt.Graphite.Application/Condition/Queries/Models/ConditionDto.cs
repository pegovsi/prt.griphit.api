using System;
using System.Collections.Generic;
using System.Text;

namespace Prt.Graphit.Application.Condition.Queries.Models
{
    public class ConditionDto
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string IconLink { get; private set; }
        public bool Readiness { get; private set; }
    }
}
