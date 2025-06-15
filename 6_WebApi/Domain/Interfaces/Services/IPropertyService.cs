using Domain.Models;

namespace Domain.Interfaces.Services
{
    public interface IPropertyService
    {
        Property? GetById( Guid id );

        IEnumerable<Property> GetAll();

        void UpdateParams(
           Guid propertyId,
           string name,
           string country,
           string city,
           double latitude,
           double longitude );

        void Delete( Guid id );

        Property? Create(
            string name,
            string country,
            string city,
            double latitude,
            double longitude );
    }
}
