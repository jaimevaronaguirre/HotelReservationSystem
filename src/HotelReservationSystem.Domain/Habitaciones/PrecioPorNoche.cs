using CleanArchitecture.Domain.Abstractions;
using HotelReservationSystem.Domain.Abstractions;
using HotelReservationSystem.Domain.Shared;

namespace HotelReservationSystem.Domain.Habitaciones
{
    public sealed class PrecioPorNoche
    {
        public Moneda Valor { get; }

        private PrecioPorNoche(Moneda valor)
        {
            Valor = valor;
        }

        public static Result<PrecioPorNoche> Crear(Moneda valor)
        {
            if (valor.Monto <= 0)
            {
                return Result.Failure<PrecioPorNoche>(new Error("PrecioPorNoche.ValorInvalido", "El precio debe ser mayor a cero"));
            }

            return Result.Success(new PrecioPorNoche(valor));
        }

        public bool EsGratis() => Valor.IsZero();
    }

}
