using CleanArchitecture.Domain.Abstractions;
using Dapper;
using HotelReservationSystem.Application.Abstractions.Data;
using HotelReservationSystem.Application.Abstractions.Messaging;

namespace HotelReservationSystem.Application.Reservas.GetReservar
{
    internal sealed class GetReservarQueryHandler : IQueryHandler<GetReservarQuery, ReservarResponse>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetReservarQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Result<ReservarResponse>> Handle(
            GetReservarQuery request,
            CancellationToken cancellationToken)
        {
            using var connection = _sqlConnectionFactory.CreateConnection();

            var sql = """
                SELECT
                    Id,
                    UserId,
                    HabitacionId,
                    Status,
                    PrecioPorNoche,
                    TipoMonedaReserva,
                    PrecioServicioAdicional,
                    TipoMonedaServicioAdicional,
                    PrecioAccesoriosHabitacion,
                    TipoMonedaAccesoriosHabitacion,
                    PrecioTotal,
                    PrecioTotalTipoMoneda,
                    DuracionInicio,
                    DuracionFinal,
                    FechaCreacion
                FROM Alquileres
                WHERE Id = @AlquilerId
            """;


            var reservar = await connection.QueryFirstOrDefaultAsync<ReservarResponse>(
                sql,
                new
                {
                    request.ReservaId
                }
                
            );

            return reservar!;

        }
    }
}
