using HotelReservationSystem.Domain.Abstractions;
using HotelReservationSystem.Domain.Shared;

namespace HotelReservationSystem.Domain.Habitaciones
{
    public sealed class Habitacion : Entity<HabitacionId>    {

        private Habitacion() {}

        public Habitacion (
            HabitacionId id,            
            TipoHabitacion tipoHabitacion,
            EstadoHabitacion estado,
            Moneda precioReserva,
            Moneda servicioAdicional,            
            DateTime? fechaUltimaReserva,
            Capacidad capacidad,
            List<AccesorioHabitacion> accesorios,
            Ubicacion ubicacion
            ): base(id)
        {

            TipoHabitacion = tipoHabitacion;
            Estado = estado;
            PrecioReserva = precioReserva;
            ServicioAdicional = servicioAdicional;
            FechaUltimaReserva = fechaUltimaReserva;
            Capacidad = capacidad;
            Accesorios = accesorios;
            Ubicacion = ubicacion;
        }
        
        public TipoHabitacion? TipoHabitacion { get; private set; }
        public Ubicacion? Ubicacion { get; private set; }
        public EstadoHabitacion? Estado { get; private set; }
        public Moneda? PrecioReserva { get; private set; }        
        public Moneda? ServicioAdicional { get; private set; }
        public DateTime? FechaUltimaReserva { get; internal set; }
        public Capacidad? Capacidad { get; private set; }        
        public List<AccesorioHabitacion> Accesorios { get; private set; } = new();        
    }
}
