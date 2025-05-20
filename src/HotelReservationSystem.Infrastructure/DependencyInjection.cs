using Dapper;
using HotelReservationSystem.Application.Abstractions.Clock;
using HotelReservationSystem.Application.Abstractions.Data;
using HotelReservationSystem.Application.Abstractions.Email;
using HotelReservationSystem.Domain.Abstractions;
using HotelReservationSystem.Domain.Habitaciones;
using HotelReservationSystem.Domain.Reservas;
using HotelReservationSystem.Domain.Users;
using HotelReservationSystem.Infrastructure.Clock;
using HotelReservationSystem.Infrastructure.Data;
using HotelReservationSystem.Infrastructure.Email;
using HotelReservationSystem.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotelReservationSystem.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddTransient<IDateTimeProvider, DateTimeProvider>();            
            services.AddTransient<IEmailService, EmailService>();

            var connectionString = configuration.GetConnectionString("Database")
                ?? throw new ArgumentNullException(nameof(configuration));

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IHabitacionRepository, HabitacionRepository>();
            services.AddScoped<IReservaRepository, ReservaRepository>();
                      

            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

            services.AddSingleton<ISqlConnectionFactory>(_ => new SqlConnectionFactory(connectionString));

            SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());
            return services;
        }
    }
}
