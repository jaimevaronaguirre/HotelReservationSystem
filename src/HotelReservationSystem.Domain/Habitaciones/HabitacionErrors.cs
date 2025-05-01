using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelReservationSystem.Domain.Abstractions;

namespace HotelReservationSystem.Domain.Habitaciones
{
    public static class HabitacionErrors
    {
        public static Error CapacidadInvalida = new(
            "Habitacion.CapacidadInvalida",
            "La capacidad debe ser mayor que cero."
        );

        public static Error UbicacionInvalida = new(
            "Habitacion.UbicacionInvalida",
            "La ubicación de la habitación debe incluir al menos el piso y el número de puerta."
        );
    }
}
