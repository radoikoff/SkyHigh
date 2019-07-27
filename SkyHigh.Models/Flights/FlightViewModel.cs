namespace SkyHigh.Models.Flights
{
    public class FlightViewModel
    {
        //public string Id { get; set; }

        public string ReferenceNumber { get; set; }

        public string SourceAirportName { get; set; }

        public string DestinationAirportName { get; set; }

        public string FlightStatus { get; set; }

        public int Distance { get; set; }

        public string AircraftType { get; set; }

        public int ReservationsCount { get; set; }
    }
}
