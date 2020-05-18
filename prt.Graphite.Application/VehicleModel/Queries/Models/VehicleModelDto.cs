using System;
using System.Collections.Generic;
using System.Text;

namespace Prt.Graphit.Application.VehicleModel.Queries.Models
{
    public class VehicleModelDto
    {
        public Guid Id { get; protected set; }
        public string Name { get; private set; }
        public string ShortName { get; private set; }
        public Guid VehicleModelTypeId { get; private set; }
        public Guid ChassiId { get; private set; }
        public string IconLink { get; private set; }
    }
}
