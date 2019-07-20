using SkyHigh.Domain.Enums;
using System.Collections.Generic;

namespace SkyHigh.Domain
{
    public class Flight
    {
        public Flight()
        {
            this.Reservations = new HashSet<FlightReservation>();
        }

        public string Id { get; set; }

        public string ReferenceNumber { get; set; }

        public string SourceAirportId { get; set; }
        public Airport SourceAirport { get; set; }

        public string DestinationAirportId { get; set; }
        public Airport DestinationAirport { get; set; }

        public FlightStatus FlightStatus { get; set; }

        public int Distance { get; set; }

        public string AircraftId { get; set; }
        public Aircraft Aircraft { get; set; }

        public ICollection<FlightReservation> Reservations { get; set; }

    }
}
