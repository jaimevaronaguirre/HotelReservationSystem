using FluentValidation;
using HotelReservationSystem.Application.Abstractions.Behaviors;
using HotelReservationSystem.Domain.Reservas;
using Microsoft.Extensions.DependencyInjection;

namespace HotelReservationSystem.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
                configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
                configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
            
            services.AddTransient<PrecioService>();
            return services;
        }
    }
}
