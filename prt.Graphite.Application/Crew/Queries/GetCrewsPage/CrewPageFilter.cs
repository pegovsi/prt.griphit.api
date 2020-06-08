using System;
using System.Collections.Generic;
using System.Text;

namespace Prt.Graphit.Application.Crew.Queries.GetCrewsPage
{
    public class CrewPageFilter
    {
        public Guid? VehicleId { get; set; }
        public Guid? MilitaryFormationId { get; set; }
    }
}
