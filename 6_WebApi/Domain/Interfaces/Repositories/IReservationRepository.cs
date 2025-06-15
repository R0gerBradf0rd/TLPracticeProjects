using Domain.Models;

namespace Domain.Interfaces.Repositories
{
    public interface IReservationRepository
    {
        Reservation? GetReservationById( Guid id );

        void CancelReservation( Guid id );

        IEnumerable<Reservation> GetAll();

        void Create( Reservation reservation );
    }
}
