using _6_WebApi.DTO;
using Domain.Models;

namespace _6_WebApi.Mappers
{
    public static class ReservationMapper
    {
        public static ReservationDto ToDto( this Reservation reservation )
        {
            return new ReservationDto
            {
                Id = reservation.Id,
                PropertyId = reservation.PropertyId,
                RoomTypeId = reservation.RoomTypeId,
                ArrivalDate = reservation.ArrivalDate,
                DepartureDate = reservation.DepartureDate,
                ArrivalTime = reservation.ArrivalTime,
                DepartureTime = reservation.DepartureTime,
                GuestName = reservation.GuestName,
                GuestPhoneNumber = reservation.GuestPhoneNumber,
                Total = reservation.Total,
                Currency = reservation.Currency
            };
        }
    }
}
