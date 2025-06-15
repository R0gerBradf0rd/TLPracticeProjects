using Domain.Models;

namespace Domain.Interfaces.Repositories
{
    public interface IReservationRepository
    {
        Reservation? GetReservationById( Guid id );

        void CancelReservation( Guid id );

        IEnumerable<Reservation> GetAll();

        Reservation? Create(
            Guid propertyId,
            Guid roomTypeId,
            DateOnly arrivalDate,
            DateOnly departureDate,
            TimeOnly arrivalTime,
            TimeOnly departureTime,
            string guestName,
            string guestphoneNumber,
            double total,
            string currency );
    }
}
