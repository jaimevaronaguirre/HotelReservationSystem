using CleanArchitecture.Domain.Abstractions;
using HotelReservationSystem.Domain.Abstractions;
using HotelReservationSystem.Domain.Habitaciones;
using HotelReservationSystem.Domain.Reservas.Event;
using HotelReservationSystem.Domain.Shared;
using HotelReservationSystem.Domain.Users;

namespace HotelReservationSystem.Domain.Reservas
{
    public sealed class Reserva : Entity<ReservaId>
    {
        private Reserva()
        {

        }
        private Reserva(
            ReservaId id,
            HabitacionId habitacionId,
            UserId userId,
            DateRange duracion,
            Moneda precioPorNoche,
            Moneda servicioAdicional,
            Moneda accesoriosHabitacion,
            Moneda precioTotal,
            ReservaStatus status,
            DateTime fechaCreacion

            ) : base(id)
        {
            HabitacionId = habitacionId;
            UserId = userId;
            Duracion = duracion;
            PrecioPorNoche = precioPorNoche;
            ServicioAdicional = servicioAdicional;
            AccesoriosHabitacion = accesoriosHabitacion;
            PrecioTotal = precioTotal;
            Status = status;
            FechaCreacion = fechaCreacion;
        }

        public HabitacionId? HabitacionId { get; private set; }
        public Users.UserId? UserId { get; private set; }
        public Moneda? PrecioPorNoche { get; private set; }
        public Moneda? ServicioAdicional { get; private set; }
        public Moneda? AccesoriosHabitacion {  get; private set; }
        public Moneda? PrecioTotal {  get; private set; }        
        public ReservaStatus Status { get; private set; }
        public DateRange? Duracion { get; private set; }
        public DateTime? FechaCreacion { get; private set; }
        public DateTime? FechaConfirmacion { get; private set; }
        public DateTime? FechaDenegacion { get; private set; }
        public DateTime? FechaCompletado { get; private set; }
        public DateTime? FechaCancelacion { get; private set; }

        public static Reserva Alojamiento(
            Habitacion habitacion,
            Users.UserId userId,
            DateRange duracion,
            DateTime fechaCreacion,
            PrecioService precioService
        )
        {
            var precioDetalle = precioService.CalcularPrecio(
                habitacion,
                duracion
                );

            var reserva = new Reserva(
               ReservaId.New(),
               habitacion.Id!,
               userId,
               duracion,
               precioDetalle.PrecioPorNoche,
               precioDetalle.ServicioAdicional,
               precioDetalle.AccesoriosHabitacion,
               precioDetalle.PrecioTotal,
               ReservaStatus.Rechazado,
               fechaCreacion
            );

            reserva.RaiseDomainEvent(new HabitacionReservadaDomainEvent(reserva.Id!));

            habitacion.FechaUltimaReserva = fechaCreacion;

            return reserva;
        }


        public Result Confirmar(DateTime utcNow)
        {
            if(Status != ReservaStatus.Reservado)
            {
                return Result.Failure(ReservaErrors.NotReserved);
            }

            Status = ReservaStatus.Confirmado;
            FechaConfirmacion = utcNow;

            RaiseDomainEvent(new ReservaConfirmadaDomainEvent(Id!));
            return Result.Success();
        }

        public Result Rechazar(DateTime utcNow)
        {
            if (Status != ReservaStatus.Reservado)
            {
                return Result.Failure(ReservaErrors.NotReserved);
            }

            Status = ReservaStatus.Rechazado;
            FechaDenegacion = utcNow;
            RaiseDomainEvent(new ReservaRechazadaDomainEvent(Id!));
            return Result.Success();
        }

        public Result Cancelar(DateTime utcNow)
        {
            if (Status != ReservaStatus.Confirmado)
            {
                return Result.Failure(ReservaErrors.NotConfirmado);
            }

            var currentDate = DateOnly.FromDateTime(utcNow);

            if (currentDate > Duracion!.Inicio)
            {
                return Result.Failure(ReservaErrors.AlreadyStarted);
            }


            Status = ReservaStatus.Cancelado;
            FechaCancelacion = utcNow;

            RaiseDomainEvent(new ReservaCanceladaDomainEvent(Id!));


            return Result.Success();
        }

        public Result Completar(DateTime utcNow)
        {
            if (Status != ReservaStatus.Confirmado)
            {
                return Result.Failure(ReservaErrors.NotConfirmado);
            }

            Status = ReservaStatus.Completado;
            FechaCompletado = utcNow;

            RaiseDomainEvent(new ReservaCompletadaDomainEvent(Id!));

            return Result.Success();
        }
    }
}
