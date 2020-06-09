namespace Prt.Graphit.Application.Vehicle.Queries.Models
{
    public class VehiclesCountByCityDto
    {
        public string[] Cities { get; private set; }
        public int[] Count { get; private set; }

        public VehiclesCountByCityDto(string[] cities, int[] count)
        {
            Cities = cities;
            Count = count;
        }
    }
}
