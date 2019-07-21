using System.ComponentModel.DataAnnotations;

namespace SkyHigh.Models.Countries
{
    public class CountryViewModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Country name must be at least 3 symbols long")]
        public string Name { get; set; }
    }
}
