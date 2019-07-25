using SkyHigh.Domain.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SkyHigh.Domain
{
    public class Flight
    {
        public Flight()
        {
            this.Reservations = new HashSet<FlightReservation>();
        }

        public string Id { get; set; }

        [Required]
        [MaxLengthAttribute(50)]
        public string ReferenceNumber { get; set; }

        [Required]
        public string SourceAirportId { get; set; }
        public Airport SourceAirport { get; set; }

        [Required]
        public string DestinationAirportId { get; set; }
        public Airport DestinationAirport { get; set; }

        [Required]
        public FlightStatus FlightStatus { get; set; }

        [Required]
        public int Distance { get; set; }

        [Required]
        public string AircraftId { get; set; }
        public Aircraft Aircraft { get; set; }

        public ICollection<FlightReservation> Reservations { get; set; }

    }
}
