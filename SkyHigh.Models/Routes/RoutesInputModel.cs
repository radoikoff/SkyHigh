using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SkyHigh.Models.Routes
{
    public class RoutesInputModel
    {
        public IEnumerable<Route> InboundRoutes { get; set; }

        public IEnumerable<Route> OutboundRoutes { get; set; }

        [Required]
        public string InboundRouteIds { get; set; }

        [Required]
        public string OutboundRouteIds { get; set; }
    }
}
