using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem.Application.Reservas.GetReservar
{
    public sealed class ReservarResponse
    {
        public Guid Id { get; init; }
        public Guid UserId { get; init; }
        public Guid HabitacionId { get; init; }
        public int Status { get; init; }
        public decimal PrecioPorNoche { get; init; }
        public string? TipoMonedaReserva {  get; init; }
        public decimal PrecioServicioAdicional { get; init; }
        public string? TipoMonedaServicioAdicional { get; init; }
        public decimal PrecioAccesoriosHabitacion {  get; init; }
        public string? TipoMonedaAccesoriosHabitacion { get; init; }
        public decimal PrecioTotal { get; init; }
        public string? PrecioTotalTipoMoneda { get; init; }

        public DateOnly DuracionInicio { get; init; }
        public DateOnly DuracionFinal { get; init; }

        public DateTime FechaCreacion { get; init; }
    }
}
