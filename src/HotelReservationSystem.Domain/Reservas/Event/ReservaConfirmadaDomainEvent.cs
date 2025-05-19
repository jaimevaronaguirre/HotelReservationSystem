using HotelReservationSystem.Domain.Abstractions;

namespace HotelReservationSystem.Domain.Reservas.Event
{
    public sealed record ReservaConfirmadaDomainEvent(ReservaId Id) : IDomainEvent;
    
}
