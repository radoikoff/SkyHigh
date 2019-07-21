using SkyHigh.Models.Cities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyHigh.Models.Countries
{
    public class CountryIndexViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<string> Cities { get; set; }
    }
}
