using System;
using System.Collections.Generic;
using System.Text;

namespace Prt.Graphit.Application.VehicleType.Queries.Models
{
    public class VehicleTypeDto
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string IconLink { get; private set; }
        public string PictureLink { get; private set; }
    }
}
