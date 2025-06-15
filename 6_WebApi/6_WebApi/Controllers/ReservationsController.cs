using _6_WebApi.DTO;
using _6_WebApi.Mappers;
using _6_WebApi.Requests.Property;
using _6_WebApi.Requests.Reservation;
using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace _6_WebApi.Controllers
{
    [ApiController]
    [Route( "api/[controller]" )]
    public class ReservationsController : ControllerBase
    {
        private readonly IPropertyService _propertyService;
        private readonly IRoomTypeService _roomTypeService;
        private readonly IReservationService _reservatonService;

        public ReservationsController(
            IPropertyService propertyService,
            IRoomTypeService roomTypeService,
            IReservationService reservatonService )
        {
            _propertyService = propertyService;
            _roomTypeService = roomTypeService;
            _reservatonService = reservatonService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ReservationDto>> GetAll(
            DateOnly?
            arrivalDate,
            DateOnly?
            departureDate,
            string? guestName )
        {
            IEnumerable<Reservation> reservations = _reservatonService.GetAllFiltred( arrivalDate, departureDate, guestName );

            return Ok( reservations
                .Select( r => r.ToDto() )
                .ToList() );
        }

        [HttpGet( "{id}" )]
        public ActionResult<ReservationDto> GetById( Guid id )
        {
            Reservation? reservation = _reservatonService.GetReservationById( id );

            return reservation == null ? NotFound() : Ok( reservation.ToDto() );
        }

        [HttpDelete( "{id}" )]
        public IActionResult Delete( Guid id )
        {
            _reservatonService.CancelReservation( id );

            return Ok();
        }

        [HttpPost]
        public IActionResult Create( [FromBody] CreateReservationRequest createReservationRequest )
        {
            Reservation? reservation = _reservatonService.CreateReservation(
                createReservationRequest.PropertyId,
                createReservationRequest.RoomTypeId,
                createReservationRequest.ArrivalDate,
                createReservationRequest.DepartureDate,
                createReservationRequest.GuestName,
                createReservationRequest.GuestPhoneNumber );
            if ( reservation == null )
            {
                return BadRequest();
            }

            return Ok( reservation.ToDto() );
        }

        [HttpGet( "search" )]
        public IActionResult Search(
            string city,
            DateOnly arrivalDate,
            DateOnly departureDate,
            int guests,
            double maxPrice )
        {
            IEnumerable<ReservationSearchResponseDto> reservationSearchResponses =
                _reservatonService.Search( city, arrivalDate, departureDate, guests, maxPrice )
                .Select( r => r.ToDto() );
            if ( reservationSearchResponses == null )
            {
                return NotFound();
            }

            return Ok( reservationSearchResponses );
        }
    }
}
