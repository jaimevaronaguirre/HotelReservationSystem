using HotelReservationSystem.Domain.Abstractions;

namespace HotelReservationSystem.Domain.Reservas.Event
{
    public sealed class ReservaConfirmadaDomainEvent(ReservaId Id) : IDomainEvent;
    
}
