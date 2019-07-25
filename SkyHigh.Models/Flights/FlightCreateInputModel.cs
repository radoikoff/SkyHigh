using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SkyHigh.Models.Flights
{
    public class FlightCreateInputModel
    {
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Reference number must be between {2} and {1} symbols")]
        [Display(Name = "Reference Number")]
        public string ReferenceNumber { get; set; }

        [Required]
        [Display(Name = "Source Airport")]
        public string SourceAirportId { get; set; }

        [Required]
        [Display(Name = "Destination Airport")]
        //TODO: Add validation for equal Airports
        public string DestinationAirportId { get; set; }

        public IEnumerable<SelectListItem> Airports { get; set; }

        [Required]
        [Range(1, 20000, ErrorMessage = "Distance must be number between {1} and {2} NM")]
        public int Distance { get; set; }

        [Required]
        [Display(Name = "Aircraft")]
        public string AircraftId { get; set; }

        public IEnumerable<SelectListItem> Aircrafts { get; set; }
    }

}
