using Domain.Interfaces.Repositories;
using Domain.Models;
using Infrastructure.Services;

namespace Infrastructure.Repositories
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        private readonly List<RoomType> _roomTypes = new();

        public RoomType Create(
            Guid propertyID,
            string name,
            double dailyPrice,
            string currency,
            int minPersonCount,
            int maxPersonCount,
            List<string> services,
            List<string> amenities )
        {
            var roomType = new RoomType()
            {
                Id = Guid.NewGuid(),
                PropertyId = propertyID,
                Name = name,
                DailyPrice = dailyPrice,
                Currency = currency,
                MinPersonCount = minPersonCount,
                MaxPersonCount = maxPersonCount,
                Services = services,
                Amenities = amenities
            };
            _roomTypes.Add( roomType );

            return roomType;
        }

        public void Delete( Guid roomTypeId )
        {
            var roomType = GetById( roomTypeId );
            if ( roomType != null )
            {
                _roomTypes.Remove( roomType );
            }
        }

        public IEnumerable<RoomType> GetAllRoomTypePropertyById( Guid propertyId ) => _roomTypes
            .Where( p => p.PropertyId == propertyId );

        public RoomType? GetById( Guid id ) => _roomTypes.FirstOrDefault( u => u.Id == id );

        public void Update(
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
            var roomType = GetById( roomTypeId );
            if ( roomType != null )
            {
                roomType.PropertyId = propertyID;
                roomType.Name = name;
                roomType.DailyPrice = dailyPrice;
                roomType.Currency = currency;
                roomType.MinPersonCount = minPersonCount;
                roomType.MaxPersonCount = maxPersonCount;
                roomType.Services = services;
                roomType.Amenities = amenities;
            }
        }
    }
}
