
using HotelReservationSystem.Domain.Abstractions;

namespace HotelReservationSystem.Domain.Reservas
{
    public static class ReservaErrors
    {
        public static Error NotFound = new Error(
        "Reserva.Found",
        "La reserva de su habitación con el Id especificado no fue encontrado"
    );

        public static Error Overlap = new Error(
        "Reserva.Overlap",
        "La reserva de su habitación esta siendo tomado por 2 o mas clientes al mismo tiempo en la misma fecha"
        );


        public static Error NotReserved = new Error(
            "Reserva.NotReserved",
            "La habitación no esta reservada"
        );

        public static Error NotConfirmado = new Error(
            "Reserva.NotConfirmed",
            "La reserva de su habitación no esta confirmada"
        );

        public static Error AlreadyStarted = new Error(
            "Reserva.AlreadyStarted",
            "La reserva de su habitación ya ha comenzado"
        );
    }
}
