using System.Security.AccessControl;
using Domain.Interfaces.Repositories;
using Domain.Models;

namespace Infrastructure.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly List<Reservation> _reservations = new()
        { new Reservation() {
            Id = Guid.NewGuid(),
            PropertyId = Guid.NewGuid(),
            RoomTypeId = Guid.NewGuid(),
            ArrivalDate = new DateOnly(2025, 06, 13),
            DepartureDate = new DateOnly(2025, 06, 15),
            ArrivalTime = new TimeOnly(12, 30),
            DepartureTime = new TimeOnly(12, 30),
            GuestName = "Svyat",
            GuestPhoneNumber = "8-800-555-35-35",
            Total = 100500,
            Currency = "rub" } };

        public void CancelReservation( Guid id )
        {
            Reservation? reservation = GetReservationById( id );
            if ( reservation != null )
            {
                _reservations.Remove( reservation );
            }
        }

        public Reservation? Create(
            Guid propertyId,
            Guid roomTypeId,
            DateOnly arrivalDate,
            DateOnly departureDate,
            TimeOnly arrivalTime,
            TimeOnly departureTime,
            string guestName,
            string guestphoneNumber,
            double total,
            string currency )
        {
            Reservation? reservation = new Reservation()
            {
                Id = Guid.NewGuid(),
                PropertyId = propertyId,
                RoomTypeId = roomTypeId,
                ArrivalDate = arrivalDate,
                DepartureDate = departureDate,
                ArrivalTime = arrivalTime,
                DepartureTime = departureTime,
                GuestName = guestName,
                GuestPhoneNumber = guestphoneNumber,
                Total = total,
                Currency = currency
            };
            _reservations.Add( reservation );

            return reservation;
        }

        public IEnumerable<Reservation> GetAll() => _reservations;

        public Reservation? GetReservationById( Guid id ) => _reservations.FirstOrDefault( r => r.Id == id );
    }
}
