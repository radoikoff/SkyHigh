namespace SkyHigh.Domain
{
    public class FlightReservation
    {
        public string FlightId { get; set; }
        public Flight Flight { get; set; }

        public string ReservationId { get; set; }
        public Reservation Reservation { get; set; }
    }
}
