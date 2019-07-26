using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkyHigh.Models.Flights
{
    public class FlightIndexViewModel
    {
        public IEnumerable<FlightViewModel> Flights { get; set; }

        public IEnumerable<FlightViewModel> Departures => this.Flights.Where(f => f.SourceAirportName.Contains(this.AirportName));

        public IEnumerable<FlightViewModel> Arrivals => this.Flights.Where(f => f.DestinationAirportName.Contains(this.AirportName));

        public string AirportName { get; set; }
    }


    public class FlightViewModel
    {
        //public string Id { get; set; }

        public string ReferenceNumber { get; set; }

        public string SourceAirportName { get; set; }

        public string DestinationAirportName { get; set; }

        public string FlightStatus { get; set; }

        public int Distance { get; set; }

        public string AircraftType { get; set; }

        public int ReservationsCount { get; set; }
    }
}
