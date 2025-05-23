using CleanArchitecture.Domain.Abstractions;
using Dapper;
using HotelReservationSystem.Application.Abstractions.Data;
using HotelReservationSystem.Application.Abstractions.Messaging;
using HotelReservationSystem.Domain.Reservas;

namespace HotelReservationSystem.Application.Habitaciones.SearchHabitaciones
{
    internal sealed class SearchHabitacionesQueryHandler
        : IQueryHandler<SearchHabitacionesQuery, IReadOnlyList<HabitacionesResponse>>

    {
        private static readonly int[] ActiveReservaStatuses =
        {
            (int)ReservaStatus.Rechazado,
            (int)ReservaStatus.Confirmado,
            (int)ReservaStatus.Completado
        };

        private readonly ISqlConnectionFactory _sqlConectionFactory;

        public SearchHabitacionesQueryHandler(ISqlConnectionFactory sqlConectionFactory)
        {
            _sqlConectionFactory = sqlConectionFactory;
        }

        public async Task<Result<IReadOnlyList<HabitacionesResponse>>> Handle(
            SearchHabitacionesQuery request,
            CancellationToken cancellationToken)
        {
            if(request.fechaInicio > request.fechaFin)
            {
                return new List<HabitacionesResponse>();
            }

            using var connection = _sqlConectionFactory.CreateConnection();

            const string sql = @"
                SELECT
                    a.HabitacionId,
                    a.TipoHabitacion,
                    a.UbicacionPiso,
                    a.UbicacionNumeroPuerta,
                    a.UbicacionVista,
                    a.UbicacionDescripcion,
                    a.Estado,
                    a.PrecioReserva_Monto,                    
                    a.PrecioReserva_TipoMoneda,
                    a.ServicioAdicional_Monto,
                    a.ServicioAdicional_TipoMoneda,
                    a.Capacidad,
                    a.Accesorios,
                    a.Version
                FROM Habitacion AS a
                WHERE NOT EXISTS (
                    SELECT 1
                    FROM Reserva AS b
                    WHERE
                        b.HabitacionId = a.HabitacionId AND
                        b.DuracionInicio <= @EndDate AND
                        b.DuracionFin >= @StartDate AND
                        b.Status IN @ActiveReservaStatuses
                )
            ";
            var habitaciones = await connection
                .QueryAsync<HabitacionesResponse, UbicacionResponse, HabitacionesResponse>
                (
                    sql, 
                    (habitacion, ubicacion) =>
                    {
                        habitacion.Ubicacion = ubicacion;
                        return habitacion;
                    },
                    new
                    {
                        StartDate = request.fechaInicio,
                        EndDate = request.fechaFin,
                        ActiveReservaStatuses
                    },
                    splitOn: "UbicacionPiso"
                );
            return habitaciones.ToList();

        }
    }
}
