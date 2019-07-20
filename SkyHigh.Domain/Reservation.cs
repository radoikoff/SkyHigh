using SkyHigh.Domain.Enums;
using System;
using System.Collections.Generic;

namespace SkyHigh.Domain
{
    public class Reservation
    {
        public Reservation()
        {
            this.Flights = new HashSet<FlightReservation>();
        }

        public string Id { get; set; }

        public string UserId { get; set; }
        public SkyHighUser User { get; set; }

        public DateTime DepartureDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public TravelClass TravelClass { get; set; }

        public ICollection<FlightReservation> Flights { get; set; }
    }
}
