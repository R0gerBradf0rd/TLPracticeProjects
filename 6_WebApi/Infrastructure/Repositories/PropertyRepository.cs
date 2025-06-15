using Domain.Models;
using Domain.Interfaces.Repositories;

namespace Infrastructure.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly List<Property> _properties = new()
        {
            new Property()
            {
                Id = Guid.NewGuid(),
                Name = "Test Hotel",
                Country = "Russia",
                City = "Moscow",
                Latitude = 1488,
                Longitude = 1111
            }
        };
        public IEnumerable<Property> GetAll() => _properties;

        public Property? GetById( Guid id ) => _properties.FirstOrDefault( u => u.Id == id );

        public void UpdateParams( Guid propertyId, Property? property )
        {
            if ( property != null )
            {
                _properties.RemoveAll( u => u.Id == propertyId );
                _properties.Add( property );
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

        public void Create( Property? property )
        {
            if ( property != null )
            {
                _properties.Add( property );
            }
        }
    }
}
