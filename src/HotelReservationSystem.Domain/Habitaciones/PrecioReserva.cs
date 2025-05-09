using CleanArchitecture.Domain.Abstractions;
using HotelReservationSystem.Domain.Abstractions;
using HotelReservationSystem.Domain.Shared;

namespace HotelReservationSystem.Domain.Habitaciones
{
    public sealed class PrecioReserva
    {
        public Moneda Valor { get; }

        private PrecioReserva(Moneda valor)
        {
            Valor = valor;
        }

        public static Result<PrecioReserva> Crear(Moneda valor)
        {
            if (valor.Monto <= 0)
            {
                return Result.Failure<PrecioReserva>(new Error("PrecioPorNoche.ValorInvalido", "El precio debe ser mayor a cero"));
            }

            return Result.Success(new PrecioReserva(valor));
        }

        public bool EsGratis() => Valor.IsZero();
    }

}
