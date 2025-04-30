using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using HotelReservationSystem.Domain.Abstractions;

namespace HotelReservationSystem.Domain.Habitaciones
{
    public sealed class Habitacion : Entity<HabitacionId>
    {

        private Habitacion() {}

        public Habitacion(
            HabitacionId id,
            NumeroHabitacion numero,
            TipoHabitacion tipo,
            EstadoHabitacion estado,
            Precio precioPorNoche,
            DateTime? fechaUltimaAlquiler,
            Capacidad capacidad,
            Ubicacion ubicacion
            ): base(id)
        {
            Id = id;
            Numero = numero;
            Tipo = tipo;
            Estado = estado;
            PrecioPorNoche = precioPorNoche;
            Capacidad = capacidad;
            Ubicacion = ubicacion;
        }

        //public HabitacionId Id { get; private set; }
        public NumeroHabitacion Numero { get; private set; }
        public TipoHabitacion Tipo { get; private set; }
        public EstadoHabitacion Estado { get; private set; }
        public Precio PrecioPorNoche { get; private set; }
        public DateTime? FechaUltimaAlquiler { get; internal set; }
        public Capacidad Capacidad { get; private set; }
        public Ubicacion Ubicacion { get; private set; }
    }
}
