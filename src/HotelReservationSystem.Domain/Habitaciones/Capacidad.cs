using CleanArchitecture.Domain.Abstractions;

namespace HotelReservationSystem.Domain.Habitaciones
{
    public sealed class Capacidad
        {
        public int Valor { get; }

        private Capacidad(int valor)
        {
            Valor = valor;
        }

        public static Result<Capacidad> Crear(int valor)
        {
            if (valor <= 0)
            {
                return Result.Failure<Capacidad>(HabitacionErrors.CapacidadInvalida);
            }

            return Result.Success(new Capacidad(valor));
        }

        // Override de Equals y GetHashCode si estás usando como value object puro
        public override bool Equals(object obj)
        {
            return obj is Capacidad capacidad && Valor == capacidad.Valor;
        }

        public override int GetHashCode() => Valor.GetHashCode();

        public override string ToString() => Valor.ToString();
    }
    
}
