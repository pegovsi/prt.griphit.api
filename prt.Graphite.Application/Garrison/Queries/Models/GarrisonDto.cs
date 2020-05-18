using System;
using System.Collections.Generic;
using System.Text;

namespace Prt.Graphit.Application.Garrison.Queries.Models
{
    public class GarrisonDto
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public decimal CoordinateX { get; private set; }
        public decimal CoordinateY { get; private set; }
        public int Rate { get; private set; }
    }
}
