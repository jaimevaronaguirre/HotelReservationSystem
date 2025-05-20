
using HotelReservationSystem.Application.Abstractions.Clock;

namespace HotelReservationSystem.Infrastructure.Clock
{
    internal sealed class DateTimeProvider : IDateTimeProvider
    {
        public DateTime currentTime => DateTime.UtcNow;
    }
}
