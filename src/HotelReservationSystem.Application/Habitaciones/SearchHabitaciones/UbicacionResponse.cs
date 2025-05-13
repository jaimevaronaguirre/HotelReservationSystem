using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem.Application.Habitaciones.SearchHabitaciones
{
    public sealed class UbicacionResponse
    {
        public string? Piso {  get; init; }
        public string? NumeroPuerta { get; init; }
        public string? Torre { get; init; }
        public string? Vista { get; init; }
        public string? DescripcionAdicional { get; init; }
        
    }
}
