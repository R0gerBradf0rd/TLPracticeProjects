namespace _6_WebApi.Requests.Reservation
{
    public class CreateReservationRequest
    {
        public Guid PropertyId { get; set; }

        public Guid RoomTypeId { get; set; }

        public DateOnly ArrivalDate { get; set; }

        public DateOnly DepartureDate { get; set; }

        public string GuestName { get; set; }

        public string GuestPhoneNumber { get; set; }
    }
}
