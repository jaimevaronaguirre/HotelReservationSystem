using FluentValidation;
using HotelReservationSystem.Domain.Reservas;
using Microsoft.Extensions.DependencyInjection;

namespace HotelReservationSystem.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
                //configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
            });

            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

            services.AddTransient<PrecioService>();
            return services;
        }
    }
}
