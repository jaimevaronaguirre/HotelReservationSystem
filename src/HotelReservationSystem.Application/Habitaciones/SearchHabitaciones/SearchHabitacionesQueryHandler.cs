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
                    a.Id,
                    a.Tipo,
                    a.Numero,
                    a.PrecioReserva,
                    a.TipoMoneda,
                    a.Piso,
                    a.NumeroPuerta,
                    a.Torre,
                    a.Vista,
                    a.DescripcionAdicional
                FROM Habitaciones AS a
                WHERE NOT EXISTS (
                    SELECT 1
                    FROM Reservas AS b
                    WHERE
                        b.HabitacionId = a.Id AND
                        b.DuracionInicio <= @EndDate AND
                        b.DuracionFinal >= @StartDate AND
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
                    splitOn: "Pais"
                );
            return habitaciones.ToList();

        }
    }
}
