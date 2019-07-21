using System.Collections.Generic;

namespace SkyHigh.Models.Cities
{
    public class CityIndexViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string CountryName { get; set; }

        public IEnumerable<string> AirportCodes { get; set; }
    }
}
