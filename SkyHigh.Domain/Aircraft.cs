using System.Collections.Generic;

namespace SkyHigh.Domain
{
    public class Aircraft
    {
        public Aircraft()
        {
            this.Flights = new HashSet<Flight>();
        }

        public string Id { get; set; }

        public string Manufacturer { get; set; }

        public string Type { get; set; }

        public string RegistrationNumber { get; set; }

        public int MaxNumberOfPassengers { get; set; }

        public ICollection<Flight> Flights { get; set; }
    }
}
