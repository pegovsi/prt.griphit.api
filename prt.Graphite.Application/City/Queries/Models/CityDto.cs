using System;

namespace Prt.Graphit.Application.City.Queries.Models
{
    public class CityDto
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Guid? GarrisonId { get; private set; }
    }
}
