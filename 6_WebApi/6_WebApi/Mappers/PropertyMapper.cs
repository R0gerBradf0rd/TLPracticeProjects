using _6_WebApi.DTO;
using Domain.Models;

namespace _6_WebApi.Mappers
{
    public static class PropertyMapper
    {
        public static PropertyDto ToDto( this Property property )
        {
            return new PropertyDto
            {
                Id = property.Id,
                Name = property.Name,
                Country = property.Country,
                City = property.City,
                Latitude = property.Latitude,
                Longitude = property.Longitude
            };
        }
    }
}
