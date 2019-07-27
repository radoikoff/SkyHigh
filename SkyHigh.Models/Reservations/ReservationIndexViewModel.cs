using Microsoft.AspNetCore.Mvc.Rendering;
using SkyHigh.Domain.Enums;
using SkyHigh.Models.Routes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SkyHigh.Models.Reservations
{
    public class ReservationIndexViewModel
    {
        public FlightSearchViewModel SearchModel { get; set; }

        public IEnumerable<Route> Routes { get; set; }
    }
}
