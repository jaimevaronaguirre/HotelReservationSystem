using HotelReservationSystem.Domain.Abstractions;

namespace HotelReservationSystem.Domain.Reservas.Event
{
    public sealed record ReservaRechazadaDomainEvent(ReservaId Id) : IDomainEvent;
    
}
