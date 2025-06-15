using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using _6_WebApi.DTO;
using _6_WebApi.Mappers;
using _6_WebApi.Requests.RoomType;
using _6_WebApi.Requests.Property;
using Domain.Interfaces.Services;

namespace _6_WebApi.Controllers
{
    [ApiController]
    [Route( "api/[controller]" )]
    public class PropertiesController : ControllerBase
    {
        private readonly IPropertyService _propertyService;
        private readonly IRoomTypeService _roomTypeService;

        public PropertiesController( IPropertyService propertyService, IRoomTypeService roomTypeService )
        {
            _propertyService = propertyService;
            _roomTypeService = roomTypeService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PropertyDto>> GetAll()
        {
            IEnumerable<Property> properties = _propertyService.GetAll();

            return Ok( properties.Select( p => p.ToDto() ).ToList() );
        }

        [HttpGet( "{id}" )]
        public ActionResult<Property> GetPropertyById( Guid id )
        {
            Property? property = _propertyService.GetById( id );
            return property == null ? NotFound() : Ok( property.ToDto() );
        }

        [HttpPost]
        public IActionResult Create( [FromBody] CreatePropertyRequest createPropertyRequest )
        {
            Property? property = _propertyService.Create(
                createPropertyRequest.Name,
                createPropertyRequest.Country,
                createPropertyRequest.City,
                createPropertyRequest.Latitude,
                createPropertyRequest.Longitude );
            if ( property != null )
            {
                return Ok( property.ToDto() );
            }

            return BadRequest( property );
        }

        [HttpPut( "{id}" )]
        public IActionResult UpdateParams( Guid id, [FromBody] CreatePropertyRequest createPropertyRequest )
        {
            Property? property = _propertyService.GetById( id );
            if ( property == null )
            {
                return NotFound();
            }

            _propertyService.UpdateParams(
                id,
                createPropertyRequest.Name,
                createPropertyRequest.Country,
                createPropertyRequest.City,
                createPropertyRequest.Latitude,
                createPropertyRequest.Longitude );

            return NoContent();
        }

        [HttpDelete( "{id}" )]
        public IActionResult Delete( Guid id )
        {
            Property? property = _propertyService.GetById( id );
            if ( property == null ) return NotFound();

            _propertyService.Delete( id );

            return NoContent();
        }

        [HttpGet( "roomTypes/{id}" )]
        public ActionResult<IEnumerable<RoomType>> GetById( Guid id )
        {
            RoomType? roomType = _roomTypeService.GetById( id );

            return roomType == null ? NotFound() : Ok( roomType.ToDto() );
        }

        [HttpGet( "{propertyId}/roomTypes" )]
        public ActionResult<RoomType> GetAllRoomTypesPropertyById( Guid propertyId )
        {
            IEnumerable<RoomType> roomType = _roomTypeService.GetAllRoomTypePropertyById( propertyId );
            return roomType == null ? NotFound() : Ok( roomType.Select( r => r.ToDto() ).ToList() );
        }

        [HttpPost( "{propertyId}/roomTypes" )]
        public IActionResult Create(
            Guid propertyId,
            [FromBody] CreateRoomTypeRequest createRoomTypeRequest )
        {
            RoomType? roomType = null;
            if ( _propertyService.GetById( propertyId ) != null )
            {
                roomType = _roomTypeService.Create(
                    propertyId,
                    createRoomTypeRequest.Name,
                    createRoomTypeRequest.DailyPrice,
                    createRoomTypeRequest.Currency,
                    createRoomTypeRequest.MinPersonCount,
                    createRoomTypeRequest.MaxPersonCount,
                    createRoomTypeRequest.Services,
                    createRoomTypeRequest.Amenities );
            }
            if ( roomType != null )
            {
                return Ok( roomType.ToDto() );
            }

            return BadRequest( roomType );
        }

        [HttpPut( "roomTypes/{id}" )]
        public IActionResult UpdateParams( Guid id, [FromBody] UpdateRoomTypeRequest updateRoomTypeRequest )
        {
            RoomType? roomType = _roomTypeService.GetById( id );
            if ( _roomTypeService.GetById( id ) != null )
            {
                _roomTypeService.UpdateParams(
                    id,
                    updateRoomTypeRequest.PropertyId,
                    updateRoomTypeRequest.Name,
                    updateRoomTypeRequest.DailyPrice,
                    updateRoomTypeRequest.Currency,
                    updateRoomTypeRequest.MinPersonCount,
                    updateRoomTypeRequest.MaxPersonCount,
                    updateRoomTypeRequest.Services,
                    updateRoomTypeRequest.Amenities );

                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete( "roomTypes/{id}" )]
        public IActionResult DeleteRoomtype( Guid id )
        {
            if ( _roomTypeService.GetById( id ) != null )
            {
                return Ok();
            }

            return NotFound();
        }
    }
}
