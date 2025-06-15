using _6_WebApi.DTO;
using Domain.Models;

namespace _6_WebApi.Mappers
{
    public static class RoomTypeMapper
    {
        public static RoomTypeDto ToDto( this RoomType roomType )
        {
            return new RoomTypeDto()
            {
                Id = roomType.Id,
                PropertyId = roomType.PropertyId,
                Name = roomType.Name,
                DailyPrice = roomType.DailyPrice,
                Currency = roomType.Currency,
                MinPersonCount = roomType.MinPersonCount,
                MaxPersonCount = roomType.MaxPersonCount,
                Services = roomType.Services,
                Amenities = roomType.Amenities
            };
        }
    }
}
