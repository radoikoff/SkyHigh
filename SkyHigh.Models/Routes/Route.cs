using SkyHigh.Models.Flights;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyHigh.Models.Routes
{
    public class Route
    {
        public IEnumerable<BookingFlightViewModel> Flights { get; set; }
    }
}
