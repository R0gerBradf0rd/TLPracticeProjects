namespace Domain.Models
{
    public class Property
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Country { get; set; }

        public string City { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
