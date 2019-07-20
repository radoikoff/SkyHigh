using System.Collections.Generic;

namespace SkyHigh.Domain
{
    public class City
    {
        public City()
        {
            this.Airports = new HashSet<Airport>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string CountryId { get; set; }
        public Country Country { get; set; }

        public ICollection<Airport> Airports { get; set; }
    }
}
