using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SkyHigh.Models.Countries
{
    public class CountryCreateInputModel
    {
        [Required]
        [MinLength(3, ErrorMessage = "Country name must be at least 3 symbols long")]
        public string Name { get; set; }
    }
}
