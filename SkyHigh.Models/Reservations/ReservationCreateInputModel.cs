using Microsoft.AspNetCore.Mvc.Rendering;
using SkyHigh.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SkyHigh.Models.Reservations
{
    public class ReservationCreateInputModel
    {
        [Required]
        [Display(Name = "From")]
        public string SourceAirportId { get; set; }

        [Required]
        [Display(Name = "To")]
        //TODO: Add validation for equal Airports
        public string DestinationAirportId { get; set; }

        public IEnumerable<SelectListItem> Airports { get; set; }


        [Required]
        [Display(Name = "Departure Date")]
        public DateTime? DepartureDate { get; set; }

        [Display(Name = "Return Date")]
        public DateTime? ReturnDate { get; set; }

        [Display(Name = "One Way")]
        public bool OneWay { get; set; }

        [Required]
        [Display(Name = "Travel Class")]
        public string TravelClass { get; set; }

        public IEnumerable<SelectListItem> TravelClasses => Enum.GetNames(typeof(TravelClass)).Select(v => new SelectListItem { Text = v, Value = v });


        //---------------
        //public IEnumerable<string> SelectedFlightIds { get; set; }

        [Required]
        public string RadioInput { get; set; }


    }
}
