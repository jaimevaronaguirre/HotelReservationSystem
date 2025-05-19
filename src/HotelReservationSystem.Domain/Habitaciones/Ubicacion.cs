using CleanArchitecture.Domain.Abstractions;
using HotelReservationSystem.Domain.Habitaciones;

namespace HotelReservationSystem.Domain.Habitaciones
{
    public sealed class Ubicacion
    {
        public string Piso { get; }
        public string NumeroPuerta { get; }       
        public string Vista { get; } // Ej: "Vista al mar", "Vista interior"
        public string DescripcionAdicional { get; } // Ej: "Cerca del ascensor", etc.

        private Ubicacion(string piso, string numeroPuerta, string vista, string descripcionAdicional)
        {
            if (string.IsNullOrWhiteSpace(piso)) throw new ArgumentException("El piso no puede ser vacío.");
            if (string.IsNullOrWhiteSpace(numeroPuerta)) throw new ArgumentException("El número de puerta no puede ser vacío.");
            Piso = piso;
            NumeroPuerta = numeroPuerta;            
            Vista = vista;
            DescripcionAdicional = descripcionAdicional;
        }

        public static Result<Ubicacion> Crear(string piso, string numeroPuerta, string vista, string descripcionAdicional)
        {
            if (string.IsNullOrWhiteSpace(piso) || string.IsNullOrWhiteSpace(numeroPuerta))
            {
                return Result.Failure<Ubicacion>(HabitacionErrors.UbicacionInvalida);
            }

            return Result.Success(new Ubicacion(piso, numeroPuerta, vista, descripcionAdicional));
        }

        public override bool Equals(object obj) =>
            obj is Ubicacion other &&
            Piso == other.Piso &&
            NumeroPuerta == other.NumeroPuerta &&            
            Vista == other.Vista &&
            DescripcionAdicional == other.DescripcionAdicional;

        public override int GetHashCode() =>
            HashCode.Combine(Piso, NumeroPuerta, Vista, DescripcionAdicional);

        public override string ToString() =>
            $"{Piso}, Puerta {NumeroPuerta}, {Vista}";
    }
}

