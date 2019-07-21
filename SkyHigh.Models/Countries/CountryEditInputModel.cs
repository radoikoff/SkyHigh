using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SkyHigh.Models.Countries
{
    public class CountryEditInputModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Country name must be at least 3 symbols long")]
        [Display(Name = "New Name")]
        public string NewName { get; set; }

        [Display(Name = "Current Name")]
        public string CurrentName { get; set; }
    }
}
