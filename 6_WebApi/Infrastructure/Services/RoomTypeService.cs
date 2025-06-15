using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Infrastructure.Services
{
    public class RoomTypeService : IRoomTypeService
    {
        private readonly IRoomTypeRepository _roomTypeRepository;
        private readonly IPropertyService _propertyService;

        public RoomTypeService( IRoomTypeRepository roomTypeRepository, IPropertyService propertyService )
        {
            _roomTypeRepository = roomTypeRepository;
            _propertyService = propertyService;
        }

        public RoomType? Create(
            Guid propertyId,
            string name,
            double dailyPrice,
            string currency,
            int minPersonCount,
            int maxPersonCount,
            List<string> services,
            List<string> amenities )
        {
            if ( _propertyService.GetById( propertyId ) == null )
            {
                return null;
            }
            RoomType? roomType = new()
            {
                Id = Guid.NewGuid(),
                PropertyId = propertyId,
                Name = name,
                DailyPrice = dailyPrice,
                Currency = currency,
                MinPersonCount = minPersonCount,
                MaxPersonCount = maxPersonCount,
                Services = services,
                Amenities = amenities
            };
            _roomTypeRepository.Create( roomType );

            return roomType;
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
            RoomType? roomType = _roomTypeRepository.GetById( propertyID );
            if ( roomType != null )
            {
                roomType.Id = roomTypeId;
                roomType.PropertyId = propertyID;
                roomType.Name = name;
                roomType.DailyPrice = dailyPrice;
                roomType.Currency = currency;
                roomType.MinPersonCount = minPersonCount;
                roomType.MaxPersonCount = maxPersonCount;
                roomType.Services = services;
                roomType.Amenities = amenities;
                _roomTypeRepository.Update( roomTypeId, roomType );
            }
        }
    }
}
