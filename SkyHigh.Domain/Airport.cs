using System.Collections.Generic;

namespace SkyHigh.Domain
{
    public class Airport
    {
        public Airport()
        {
            this.Arrivals = new HashSet<Flight>();
            this.Departures = new HashSet<Flight>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string IcaoCode { get; set; }

        public string CityId { get; set; }
        public City City { get; set; }

        public ICollection<Flight> Arrivals { get; set; }

        public ICollection<Flight> Departures { get; set; }

        //List of adjacent Airports

    }
}
