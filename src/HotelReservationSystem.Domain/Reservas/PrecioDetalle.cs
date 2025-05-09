using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelReservationSystem.Domain.Shared;

namespace HotelReservationSystem.Domain.Reservas
{
    public record PrecioDetalle
    (
        Moneda PrecioPorNoche,
        Moneda ServicioAdicional,
        Moneda AccesoriosHabitacion,
        Moneda PrecioTotal
    );
}
