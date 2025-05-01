using HotelReservationSystem.Domain.Abstractions;
using HotelReservationSystem.Domain.Shared;

namespace HotelReservationSystem.Domain.Habitaciones
{
    public sealed class Habitacion : Entity<HabitacionId>
    {

        private Habitacion() {}

        public Habitacion (
            HabitacionId id,
            NumeroHabitacion numero,
            TipoHabitacion tipo,
            EstadoHabitacion estado,
            PrecioPorNoche precio,
            Moneda servicioAdicional,            
            DateTime? fechaUltimaReserva,
            Capacidad capacidad,
            List<AccesorioHabitacion> accesorios,
            Ubicacion ubicacion
            ): base(id)
        {            
            Numero = numero;
            Tipo = tipo;
            Estado = estado;
            PrecioPorNoche = precio;
            ServicioAdicional = servicioAdicional;
            FechaUltimaReserva = fechaUltimaReserva;
            Capacidad = capacidad;
            Accesorios = accesorios;
            Ubicacion = ubicacion;
        }

        //public HabitacionId Id { get; private set; }
        public NumeroHabitacion? Numero { get; private set; }
        public TipoHabitacion? Tipo { get; private set; }
        public Ubicacion? Ubicacion { get; private set; }
        public EstadoHabitacion? Estado { get; private set; }
        public PrecioPorNoche? PrecioPorNoche { get; private set; }        
        public Moneda? ServicioAdicional { get; private set; }
        public DateTime? FechaUltimaReserva { get; internal set; }
        public Capacidad? Capacidad { get; private set; }        
        public List<AccesorioHabitacion> Accesorios { get; private set; } = new();
    }
}
