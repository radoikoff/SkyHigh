using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SkyHigh.Models.Airports
{
    public class AirportCreateInputModel
    {
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Airport name must be between {2} and {1} symbols")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "ICAO Code must be between {2} and {1} symbols")]
        [Display(Name = "ICAO Code")]
        public string IcaoCode { get; set; }

        [Required]
        public string CityId { get; set; }

        public IEnumerable<SelectListItem> Cities { get; set; }
    }
}
