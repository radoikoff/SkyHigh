using SkyHigh.Models.Flights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkyHigh.Models.Routes
{
    public class Route
    {
        public string Id => string.Join(',', this.Flights.Select(f => f.Id).ToArray());

        public IEnumerable<BookingFlightViewModel> Flights { get; set; }

        public TimeSpan StartTime => DateTime.Now.TimeOfDay;

        public TimeSpan EndTime => StartTime.Add(new TimeSpan(1, 12, 0));

        public string Duration => $"{(EndTime - StartTime).Hours}h {(EndTime - StartTime).Minutes}min";

        public int Price => 560;
    }
}
