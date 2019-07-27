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
}
