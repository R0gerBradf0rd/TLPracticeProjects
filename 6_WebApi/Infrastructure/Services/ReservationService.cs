using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Infrastructure.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IPropertyRepository _propertyRepository;
        private readonly IRoomTypeRepository _roomTypeRepository;

        public ReservationService(
            IReservationRepository reservationRepository,
            IRoomTypeRepository roomTypeRepository,
            IPropertyRepository propertyRepository )
        {
            _reservationRepository = reservationRepository;
            _propertyRepository = propertyRepository;
            _roomTypeRepository = roomTypeRepository;
        }
        public void CancelReservation( Guid id )
        {
            _reservationRepository.CancelReservation( id );
        }

        public IEnumerable<Reservation> GetAll()
        {
            return _reservationRepository.GetAll();
        }

        public Reservation GetReservationById( Guid id )
        {
            return _reservationRepository.GetReservationById( id );
        }

        private bool IsReservationExist( Guid roomTypeId )
        {
            foreach ( var reservation in _reservationRepository.GetAll() )
            {
                if ( reservation.RoomTypeId == roomTypeId )
                {
                    return true;
                }
            }

            return false;
        }

        public Reservation? CreateReservation(
            Guid propertyId,
            Guid roomTypeId,
            DateOnly arrivalDate,
            DateOnly departureDate,
            string guestName,
            string guestPhoneNumber )
        {
            var property = _propertyRepository.GetById( propertyId );
            var roomType = _roomTypeRepository.GetById( roomTypeId );
            if ( roomType == null || property == null )
            {
                return null;
            }
            if ( IsReservationExist( roomTypeId ) )
            {
                return null;
            }
            var arrivalTime = new TimeOnly( 10, 00 );
            var departureTime = new TimeOnly( 20, 00 );
            double total = ( departureDate.DayNumber - arrivalDate.DayNumber ) * roomType.DailyPrice;
            string currency = roomType.Currency;

            Reservation? reservation = new()
            {
                Id = Guid.NewGuid(),
                PropertyId = propertyId,
                RoomTypeId = roomTypeId,
                ArrivalDate = arrivalDate,
                DepartureDate = departureDate,
                ArrivalTime = arrivalTime,
                DepartureTime = departureTime,
                GuestName = guestName,
                GuestPhoneNumber = guestPhoneNumber,
                Total = total,
                Currency = currency
            };
            _reservationRepository.Create( reservation );

            return reservation;
        }

        public IEnumerable<ReservationSearchResponse> Search(
            string city,
            DateOnly arrivalDate,
            DateOnly departureDate,
            int guestsAmount,
            double maxPrice )
        {
            List<ReservationSearchResponse> reservationSearchResponses = new List<ReservationSearchResponse>();
            IEnumerable<Reservation> reservations = _reservationRepository.GetAll();
            IEnumerable<RoomType> roomTypes;
            IEnumerable<Property> properties = _propertyRepository.GetAll()
                .Where( p => p.City == city );
            foreach ( var property in properties )
            {
                ReservationSearchResponse reservationSearchResponse;
                if ( _roomTypeRepository.GetAllRoomTypePropertyById( property.Id ) != null )
                {
                    roomTypes = _roomTypeRepository.GetAllRoomTypePropertyById( property.Id );
                    foreach ( var roomType in roomTypes )
                    {
                        if ( guestsAmount > roomType.MaxPersonCount || guestsAmount < 1 )
                        {
                            continue;
                        }
                        if ( ( departureDate.DayNumber - arrivalDate.DayNumber ) * roomType.DailyPrice > maxPrice )
                        {
                            continue;
                        }
                        foreach ( var reservation in reservations )
                        {
                            if ( reservation.RoomTypeId != roomType.Id )
                            {
                                reservationSearchResponse = new ReservationSearchResponse()
                                {
                                    PropertyId = property.Id,
                                    PropertyName = property.Name,
                                    PropertyCity = property.City,
                                    PropertyCountry = property.Country,
                                    RoomTypeId = roomType.Id,
                                    RoomTypeName = roomType.Name,
                                    RoomTypeServices = roomType.Services,
                                    RoomTypeAmenities = roomType.Amenities,
                                    DailyPrice = roomType.DailyPrice
                                };

                                reservationSearchResponses.Add( reservationSearchResponse );
                            }
                        }
                    }
                }
            }
            if ( reservationSearchResponses.Count > 0 )
            {
                return reservationSearchResponses;
            }
            return null;
        }

        public IEnumerable<Reservation> GetAllFiltred(
            DateOnly? arrivalDate,
            DateOnly? departureDate,
            string? guestName )
        {
            IEnumerable<Reservation> reservations = _reservationRepository.GetAll();
            if ( arrivalDate != null )
            {
                reservations = reservations.Where( r => r.ArrivalDate == arrivalDate );
            }
            if ( departureDate != null )
            {
                reservations = reservations.Where( r => r.DepartureDate == departureDate );
            }
            if ( guestName != null )
            {
                reservations = reservations.Where( r => r.GuestName == guestName );
            }

            return reservations;
        }
    }
}
