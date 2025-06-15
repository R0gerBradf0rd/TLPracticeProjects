using Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Services
{
    public static class Bindings
    {
        public static IServiceCollection AddServices( this IServiceCollection services )
        {
            services.AddScoped<IPropertyService, PropertyService>();
            services.AddScoped<IRoomTypeService, RoomTypeService>();
            services.AddScoped<IReservationService, ReservationService>();

            return services;
        }
    }
}
