using System.Collections.Generic;

namespace SkyHigh.Domain
{
    public class Country
    {
        public Country()
        {
            this.Cities = new HashSet<City>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<City> Cities { get; set; }
    }
}
