using HotelReservationSystem.Domain.Habitaciones;

namespace HotelReservationSystem.Domain.Reservas
{
    public interface IReservaRepository
    {
        Task<Reserva?> GetByIdAsync(ReservaId id, CancellationToken cancellationToken = default);

        Task<bool> IsOverlappingAsync(
            Habitacion habitacion,
            DateRange duracion,
            CancellationToken cancellationToken = default
        );

        void Add(Reserva reserva );
    }
}
