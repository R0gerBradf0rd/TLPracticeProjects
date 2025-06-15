namespace Domain.Models
{
    public class ReservationSearchResponse
    {
        public Guid PropertyId { get; set; }

        public string PropertyName { get; set; }

        public string PropertyCountry { get; set; }

        public string PropertyCity { get; set; }

        public Guid RoomTypeId { get; set; }

        public string RoomTypeName { get; set; }

        public double DailyPrice { get; set; }

        public List<string> RoomTypeServices { get; set; }

        public List<string> RoomTypeAmenities { get; set; }
    }
}
