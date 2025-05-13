namespace HotelReservationSystem.Application.Habitaciones.SearchHabitaciones
{
    public sealed class HabitacionesResponse
    {
        public Guid Id { get; init; }

        public string? Tipo { get; init; }
        public string? Numero { get; init; }

        public decimal PrecioReserva { get; init; }

        public string? TipoMoneda { get; init; }

        public UbicacionResponse? Ubicacion { get; set; }
    }
}
