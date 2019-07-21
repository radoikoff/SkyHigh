using Microsoft.AspNetCore.Mvc.Rendering;
using SkyHigh.Models.Countries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SkyHigh.Models.Cities
{
    public class CityEditInputModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "City name must be at least 3 symbols long")]
        [Display(Name= "City name")]
        public string NewName { get; set; }

        [Required(ErrorMessage = "Please select a country")]
        public string CountryId { get; set; }

        public IEnumerable<SelectListItem> Countries { get; set; }

        [Display(Name = "Current Name")]
        public string CurrentName { get; set; }

        [Display(Name = "Current Country")]
        public string CurrentCountry { get; set; }
    }
}
