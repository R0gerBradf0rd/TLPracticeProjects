using _6_WebApi.DTO;
using Domain.Models;

namespace _6_WebApi.Mappers
{
    public static class ReservationSearchResponseMapper
    {
        public static ReservationSearchResponseDto ToDto( this ReservationSearchResponse reservationSearchResponse )
        {
            return new ReservationSearchResponseDto
            {
                PropertyId = reservationSearchResponse.PropertyId,
                PropertyName = reservationSearchResponse.PropertyName,
                PropertyCountry = reservationSearchResponse.PropertyCountry,
                PropertyCity = reservationSearchResponse.PropertyCity,
                RoomTypeId = reservationSearchResponse.RoomTypeId,
                RoomTypeName = reservationSearchResponse.RoomTypeName,
                DailyPrice = reservationSearchResponse.DailyPrice,
                RoomTypeServices = reservationSearchResponse.RoomTypeServices,
                RoomTypeAmenities = reservationSearchResponse.RoomTypeAmenities
            };
        }
    }
}
