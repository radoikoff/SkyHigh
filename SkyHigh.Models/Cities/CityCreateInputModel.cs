using Microsoft.AspNetCore.Mvc.Rendering;
using SkyHigh.Models.Countries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SkyHigh.Models.Cities
{
    public class CityCreateInputModel
    {
        [Required]
        [MinLength(3, ErrorMessage = "City name must be at least 3 symbols long")]
        [Display(Name= "City name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please select a country")]
        public string CountryId { get; set; }

        public List<SelectListItem> Countries { get; set; }
    }
}
