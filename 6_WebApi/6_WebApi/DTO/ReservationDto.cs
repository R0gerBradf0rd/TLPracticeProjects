namespace _6_WebApi.DTO
{
    public class ReservationDto
    {
        public Guid Id { get; set; }

        public Guid PropertyId { get; set; }

        public Guid RoomTypeId { get; set; }

        public DateOnly ArrivalDate { get; set; }

        public DateOnly DepartureDate { get; set; }

        public TimeOnly ArrivalTime { get; set; }

        public TimeOnly DepartureTime { get; set; }

        public string GuestName { get; set; }

        public string GuestPhoneNumber { get; set; }

        public double Total { get; set; }

        public string Currency { get; set; }
    }
}
