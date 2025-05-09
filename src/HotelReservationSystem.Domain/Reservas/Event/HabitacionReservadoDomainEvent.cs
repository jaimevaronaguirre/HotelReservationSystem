using HotelReservationSystem.Domain.Abstractions;

namespace HotelReservationSystem.Domain.Reservas.Event
{
    public sealed class HabitacionReservadoDomainEvent(ReservaId Id) : IDomainEvent;
    
}
