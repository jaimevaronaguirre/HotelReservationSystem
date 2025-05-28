using System.Text.Json;
using Bogus;
using Dapper;
using HotelReservationSystem.Application.Abstractions.Data;
using HotelReservationSystem.Domain.Habitaciones;
using HotelReservationSystem.Domain.Shared;
using HotelReservationSystem.Domain.Users;
using HotelReservationSystem.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace HotelReservationSystem.Api.Extensions
{
    public static class SeedDataExtensions
    {
        public static void SeedDataAuthentication(
        this IApplicationBuilder app
        )
        {
            using var scope = app.ApplicationServices.CreateScope();
            var service = scope.ServiceProvider;
            var loggerFactory = service.GetRequiredService<ILoggerFactory>();

            try
            {
                var context = service.GetRequiredService<ApplicationDbContext>();

                if (!context.Set<User>().Any())
                {
                    var passwordHash = BCrypt.Net.BCrypt.HashPassword("Test123$");

                    var user = User.Create(
                        new Nombre("Vaxi"),
                        new Apellido("Drez"),
                        new Email("vaxi.drez@gmail.com"),
                        new PasswordHash(passwordHash)
                    );

                    context.Add(user);

                    passwordHash = BCrypt.Net.BCrypt.HashPassword("Admin123$");

                    user = User.Create(
                    new Nombre("Admin"),
                    new Apellido("Admin"),
                    new Email("admin@gmail.com"),
                    new PasswordHash(passwordHash)
                    );

                    context.Add(user);
                    context.SaveChangesAsync().Wait();

                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<ApplicationDbContext>();
                logger.LogError(ex.Message);

            }
        }
    
        public static void SeedData(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var sqlConnectionFactory = scope.ServiceProvider.GetRequiredService<ISqlConnectionFactory>();
            using var connection = sqlConnectionFactory.CreateConnection();
            var faker = new Faker();


            List<object> habitaciones = new();

            for (var i = 0; i < 50; i++)
            {
                var ubicacion = Ubicacion.Crear(
                piso: faker.Random.Int(1, 10).ToString(),
                numeroPuerta: faker.Random.Int(1, 100).ToString(),
                vista: faker.Lorem.Word(),
                descripcionAdicional: faker.Lorem.Sentence()
                ).Value;

                habitaciones.Add(new
                {
                    HabitacionId = Guid.NewGuid(),
                    TipoHabitacion = faker.PickRandom<TipoHabitacion>(),
                    UbicacionPiso = ubicacion?.Piso,
                    UbicacionNumeroPuerta = ubicacion?.NumeroPuerta,
                    UbicacionVista = ubicacion?.Vista,
                    UbicacionDescripcion = ubicacion?.DescripcionAdicional,
                    Estado = faker.PickRandom<EstadoHabitacion>(),
                    PrecioReserva_Monto = faker.Random.Decimal(1000, 20000),
                    PrecioReserva_TipoMoneda = "USD",
                    ServicioAdicional_Monto = faker.Random.Decimal(100, 200),
                    ServicioAdicional_TipoMoneda = "USD",
                    FechaUltimaReserva = faker.Date.Past(),
                    Capacidad = faker.Random.Int(1, 5),
                    Accesorios = JsonSerializer.Serialize(new List<int> { (int)AccesorioHabitacion.Wifi, (int)AccesorioHabitacion.Minibar }),
                    //Accesorios = new List<int> { (int)AccesorioHabitacion.Wifi, (int)AccesorioHabitacion.Minibar },                   
                    Version = 1 // Puedes actualizarlo según necesites

                });
            }

            const string sql = """
            INSERT INTO [HotelReservaHabitacionBD].[dbo].[Habitacion]
            ([HabitacionId], [TipoHabitacion], [UbicacionPiso], [UbicacionNumeroPuerta], [UbicacionVista], [UbicacionDescripcion],
            [Estado], [PrecioReserva_Monto], [PrecioReserva_TipoMoneda], [ServicioAdicional_Monto], [ServicioAdicional_TipoMoneda],
            [FechaUltimaReserva], [Capacidad], [Accesorios], [Version])
            VALUES(@HabitacionId, @TipoHabitacion, @UbicacionPiso, @UbicacionNumeroPuerta, @UbicacionVista, @UbicacionDescripcion,
            @Estado, @PrecioReserva_Monto, @PrecioReserva_TipoMoneda, @ServicioAdicional_Monto, @ServicioAdicional_TipoMoneda,
            @FechaUltimaReserva, @Capacidad, @Accesorios,@Version)
            """;

            connection.Execute(sql, habitaciones);

        }
    }
}
