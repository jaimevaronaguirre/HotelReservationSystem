using HotelReservationSystem.Application.Abstractions.Messaging;

namespace HotelReservationSystem.Application.Users.RegisterUser
{
    public sealed record RegisterUserCommand(
        string Email,
        string Nombre,
        string Apellidos,
        string Password
    ): ICommand<Guid>;
    
}
