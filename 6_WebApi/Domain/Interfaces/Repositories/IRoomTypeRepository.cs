using Domain.Models;

namespace Domain.Interfaces.Repositories
{
    public interface IRoomTypeRepository
    {
        RoomType Create(
            Guid propertyId,
            string name,
            double dailyPrice,
            string currency,
            int minPersonCount,
            int maxPersonCount,
            List<string> services,
            List<string> amenities );

        IEnumerable<RoomType> GetAllRoomTypePropertyById( Guid id );

        RoomType? GetById( Guid id );

        void Update(
            Guid id,
            Guid propertyId,
            string name,
            double dailyPrice,
            string currency,
            int minPersonCount,
            int maxPersonCount,
            List<string> services,
            List<string> amenities
            );

        void Delete( Guid roomTypeId );
    }
}
