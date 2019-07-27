namespace SkyHigh.Models.Flights
{
    public class BookingFlightViewModel
    {
        public string Id { get; set; }

        public string ReferenceNumber { get; set; }

        public string SourceAirportIcaoCode { get; set; }

        public string DestinationAirportIcaoCode { get; set; }

        public int Distance { get; set; }

        public string AircraftType { get; set; }
    }
}
