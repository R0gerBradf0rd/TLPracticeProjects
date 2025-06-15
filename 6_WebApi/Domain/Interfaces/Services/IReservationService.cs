using Domain.Models;

namespace Domain.Interfaces.Services
{
    public interface IReservationService
    {
        Reservation GetReservationById( Guid id );

        void CancelReservation( Guid id );

        IEnumerable<Reservation> GetAll();

        IEnumerable<Reservation> GetAllFiltred(
            DateOnly? arrivalDate,
            DateOnly? departureDate,
            string? guestName );

        IEnumerable<ReservationSearchResponse> Search(
            string city,
            DateOnly arrivalDate,
            DateOnly departureDate,
            int guestsAmount,
            double maxPeice );

        Reservation? CreateReservation(
            Guid propertyId,
            Guid roomTypeId,
            DateOnly arrivalDate,
            DateOnly departureDate,
            string guestName,
            string guestPhoneNumber );
    }
}
