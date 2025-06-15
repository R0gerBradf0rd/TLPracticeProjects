using Domain.Models;

namespace Domain.Interfaces.Repositories
{
    public interface IPropertyRepository
    {
        Property? Create(
            string name,
            string country,
            string city,
            double latitude,
            double longitude
            );

        IEnumerable<Property> GetAll();

        Property? GetById( Guid id );

        void UpdateParams(
            Guid id,
            string name,
            string country,
            string city,
            double latitude,
            double longitude
            );

        void Delete( Guid id );
    }
}
