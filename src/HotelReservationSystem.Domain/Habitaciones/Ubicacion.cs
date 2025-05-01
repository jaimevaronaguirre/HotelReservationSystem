using CleanArchitecture.Domain.Abstractions;

namespace HotelReservationSystem.Domain.Habitaciones
{
    public sealed class Ubicacion
    {
        public string Piso { get; }
        public string NumeroPuerta { get; }
        public string Torre { get; } // Opcional si el hotel tiene varias torres o alas
        public string Vista { get; } // Ej: "Vista al mar", "Vista interior"
        public string DescripcionAdicional { get; } // Ej: "Cerca del ascensor", etc.

        private Ubicacion(string piso, string numeroPuerta, string torre, string vista, string descripcionAdicional)
        {
            Piso = piso;
            NumeroPuerta = numeroPuerta;
            Torre = torre;
            Vista = vista;
            DescripcionAdicional = descripcionAdicional;
        }

        public static Result<Ubicacion> Crear(string piso, string numeroPuerta, string torre, string vista, string descripcionAdicional)
        {
            if (string.IsNullOrWhiteSpace(piso) || string.IsNullOrWhiteSpace(numeroPuerta))
            {
                return Result.Failure<Ubicacion>(HabitacionErrors.UbicacionInvalida);
            }

            return Result.Success(new Ubicacion(piso, numeroPuerta, torre, vista, descripcionAdicional));
        }

        public override bool Equals(object obj) =>
            obj is Ubicacion other &&
            Piso == other.Piso &&
            NumeroPuerta == other.NumeroPuerta &&
            Torre == other.Torre &&
            Vista == other.Vista &&
            DescripcionAdicional == other.DescripcionAdicional;

        public override int GetHashCode() =>
            HashCode.Combine(Piso, NumeroPuerta, Torre, Vista, DescripcionAdicional);

        public override string ToString() =>
            $"{Piso}, Puerta {NumeroPuerta}, {Torre}, {Vista}";
    }
}
