using HotelReservationSystem.Application.Abstractions.Messaging;

namespace HotelReservationSystem.Application.Reservas.ReservaHabitacion
{
    public record ReservaHabitacionCammand(
        Guid HabitacionId,
        Guid UserId,
        DateOnly FechaInicio,
        DateOnly FechaFin
    ) : ICommand<Guid>;
    
}
