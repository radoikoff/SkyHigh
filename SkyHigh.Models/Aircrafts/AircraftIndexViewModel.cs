using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SkyHigh.Models.Aircrafts
{
    public class AircraftIndexViewModel
    {
        public string Id { get; set; }

        public string Manufacturer { get; set; }

        public string Type { get; set; }

        public string RegistrationNumber { get; set; }

        public int MaxNumberOfPassengers { get; set; }
    }
}
