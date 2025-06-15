using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Infrastructure.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository;

        public PropertyService( IPropertyRepository propertyRepository )
        {
            _propertyRepository = propertyRepository;
        }
        public Property? GetById( Guid id )
        {
            return _propertyRepository.GetById( id );
        }

        public IEnumerable<Property> GetAll()
        {
            return _propertyRepository.GetAll();
        }

        public void UpdateParams(
            Guid propertyId,
            string name,
            string country,
            string city,
            double latitude,
            double longitude )
        {
            _propertyRepository.UpdateParams(
            propertyId,
            name,
            country,
            city,
            latitude,
            longitude );
        }

        public void Delete( Guid id )
        {
            _propertyRepository.Delete( id );
        }

        public Property? Create(
            string name,
            string country,
            string city,
            double latitude,
            double longitude )
        {
            return _propertyRepository.Create(
            name,
            country,
            city,
            latitude,
            longitude );
        }
    }
}
