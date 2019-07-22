using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SkyHigh.Models.Aircrafts
{
    public class AircraftCreateInputModel
    {
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Manufacturer must be between {2} and {1} symbols")]
        public string Manufacturer { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "Aircraft type must be between {2} and {1} symbols")]
        [Display(Name = "Aircraft Type")]
        public string Type { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "Registration number must be between {2} and {1} symbols")]
        [Display(Name = "Registration Number")]
        public string RegistrationNumber { get; set; }

        [Required]
        [Range(1, 500, ErrorMessage = "Number of seats must be between {1} and {2}")]
        [Display(Name = "Number of seats")]
        public int MaxNumberOfPassengers { get; set; }
    }
}
