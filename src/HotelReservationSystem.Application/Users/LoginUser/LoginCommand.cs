using HotelReservationSystem.Application.Abstractions.Messaging;

namespace HotelReservationSystem.Application.Users.LoginUser
{
    public record LoginCommand(string Email, string Password) : ICommand<string>;    
}
