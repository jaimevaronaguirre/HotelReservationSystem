using HotelReservationSystem.Application.Abstractions.Messaging;

namespace HotelReservationSystem.Application.Habitaciones.SearchHabitaciones
{
    public sealed record SearchHabitacionesQuery(
        DateOnly fechaInicio,
        DateOnly fechaFin
    ) : IQuery<IReadOnlyList<HabitacionesResponse>>;
    
}
