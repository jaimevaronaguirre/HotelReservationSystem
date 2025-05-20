namespace HotelReservationSystem.Api.Controllers.Reservas
{
    public sealed record ReservarHabitacionRequest(
        Guid HabitacionId,
        Guid UserId,
        DateOnly StartDate,
        DateOnly EndDate
    );
}
