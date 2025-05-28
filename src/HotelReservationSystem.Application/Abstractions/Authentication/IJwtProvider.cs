using HotelReservationSystem.Domain.Users;

namespace HotelReservationSystem.Application.Abstractions.Authentication
{
    public interface IJwtProvider
    {
        Task<string> Generate(User user);
    }
}
