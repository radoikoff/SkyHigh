using System.Collections.Generic;

namespace SkyHigh.Models.Cities
{
    public class CityViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string CountryName { get; set; }

        public List<string> Airports { get; set; }
    }
}
