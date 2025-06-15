using Domain.Models;

namespace Domain.Interfaces.Services
{
    public interface IPropertyService
    {
        Property? GetById( Guid id );

        public IEnumerable<Property> GetAll();

        public void UpdateParams(
           Guid propertyId,
           string name,
           string country,
           string city,
           double latitude,
           double longitude );

        public void Delete( Guid id );

        public Property? Create(
            string name,
            string country,
            string city,
            double latitude,
            double longitude );
    }
}
