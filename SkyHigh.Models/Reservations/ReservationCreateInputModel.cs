using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SkyHigh.Models.Reservations
{
    public class ReservationCreateInputModel
    {
        [Required]
        public DateTime DepartureDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        [Required]
        public string TravelClass { get; set; }

        //----

        public IEnumerable<string> SelectedFlightIds { get; set; }

        //Flights section



        [Required]
        [Display(Name = "Source Airport")]
        public string SourceAirportId { get; set; }

        [Required]
        [Display(Name = "Destination Airport")]
        //TODO: Add validation for equal Airports
        public string DestinationAirportId { get; set; }

        public IEnumerable<SelectListItem> Airports { get; set; }
    }
}
