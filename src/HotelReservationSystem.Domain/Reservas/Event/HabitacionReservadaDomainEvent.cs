using HotelReservationSystem.Domain.Abstractions;

namespace HotelReservationSystem.Domain.Reservas.Event
{
    public sealed record HabitacionReservadaDomainEvent(ReservaId ReservaId) : IDomainEvent;
}
