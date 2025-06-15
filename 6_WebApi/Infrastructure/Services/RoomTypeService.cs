using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Infrastructure.Services
{
    public class RoomTypeService : IRoomTypeService
    {
        private readonly IRoomTypeRepository _roomTypeRepository;

        public RoomTypeService( IRoomTypeRepository roomTypeRepository )
        {
            _roomTypeRepository = roomTypeRepository;
        }

        public RoomType? Create(
            Guid propertyID,
            string name,
            double dailyPrice,
            string currency,
            int minPersonCount,
            int maxPersonCount,
            List<string> services,
            List<string> amenities )
        {
            return _roomTypeRepository.Create(
                propertyID,
                name,
                dailyPrice,
                currency,
                minPersonCount,
                maxPersonCount,
                services,
                amenities );
        }

        public void Delete( Guid id )
        {
            _roomTypeRepository.Delete( id );
        }

        public IEnumerable<RoomType> GetAllRoomTypePropertyById( Guid propertyId )
        {
            return _roomTypeRepository.GetAllRoomTypePropertyById( propertyId );
        }

        public RoomType? GetById( Guid id )
        {
            return _roomTypeRepository.GetById( id );
        }

        public void UpdateParams(
            Guid roomTypeId,
            Guid propertyID,
            string name,
            double dailyPrice,
            string currency,
            int minPersonCount,
            int maxPersonCount,
            List<string> services,
            List<string> amenities )
        {
            _roomTypeRepository.Update(
                roomTypeId,
                propertyID,
                name,
                dailyPrice,
                currency,
                minPersonCount,
                maxPersonCount,
                services,
                amenities );
        }
    }
}
