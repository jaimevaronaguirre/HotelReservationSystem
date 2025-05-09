using HotelReservationSystem.Domain.Abstractions;

namespace HotelReservationSystem.Domain.Users.Events
{
    public sealed record UserCreatedDomainEvent(UserId UserId) : IDomainEvent;
    
}
