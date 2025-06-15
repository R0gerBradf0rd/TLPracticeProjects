using Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Repositories
{
    public static class Bindings
    {
        public static IServiceCollection AddRepositories( this IServiceCollection services )
        {
            services.AddSingleton<IPropertyRepository, PropertyRepository>();
            services.AddSingleton<IRoomTypeRepository, RoomTypeRepository>();
            services.AddSingleton<IReservationRepository, ReservationRepository>();

            return services;
        }
    }
}
