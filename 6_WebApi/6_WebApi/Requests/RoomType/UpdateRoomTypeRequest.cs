namespace _6_WebApi.Requests.RoomType
{
    public class UpdateRoomTypeRequest
    {
        public Guid PropertyId { get; set; }

        public string Name { get; set; }

        public double DailyPrice { get; set; }

        public string Currency { get; set; }

        public int MinPersonCount { get; set; }

        public int MaxPersonCount { get; set; }

        public List<string> Services { get; set; }

        public List<string> Amenities { get; set; }
    }
}
