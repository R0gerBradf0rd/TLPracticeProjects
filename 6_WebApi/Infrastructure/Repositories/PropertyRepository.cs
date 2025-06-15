using Domain.Models;
using Domain.Interfaces.Repositories;

namespace Infrastructure.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly List<Property> _properties = new()
        { new Property() { Id = Guid.NewGuid(), Name = "Test Hotel", Country = "Russia", City = "Moscow", Latitude = 1488, Longitude = 1111 } };
        public IEnumerable<Property> GetAll() => _properties;

        public Property? GetById( Guid id ) => _properties.FirstOrDefault( u => u.Id == id );

        public void UpdateParams(
            Guid propertyId,
            string name,
            string country,
            string city,
            double latitude,
            double longitude )
        {
            var property = GetById( propertyId );
            if ( property != null )
            {
                property.Name = name;
                property.Country = country;
                property.City = city;
                property.Latitude = latitude;
                property.Longitude = longitude;
            }
        }

        public void Delete( Guid id )
        {
            var property = GetById( id );
            if ( property != null )
            {
                _properties.Remove( property );
            }
        }

        public Property? Create(
            string name,
            string country,
            string city,
            double latitude,
            double longitude )
        {
            var property = new Property
            {
                Id = Guid.NewGuid(),
                Name = name,
                Country = country,
                City = city,
                Latitude = latitude,
                Longitude = longitude
            };
            _properties.Add( property );

            return property;
        }
    }
}
