using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Abstractions;
using HotelReservationSystem.Domain.Abstractions;
using HotelReservationSystem.Domain.Habitaciones;
using HotelReservationSystem.Domain.Reservas;
using HotelReservationSystem.Domain.Reviews.Events;

namespace HotelReservationSystem.Domain.Reviews
{
    public sealed class Review : Entity<ReviewId>
    {
        private Review() { }

        private Review(
            ReviewId id,
            Habitaciones.HabitacionId habitacionId,
            ReservaId reservaId,
            Users.UserId userId,
            Rating rating,
            Comentario comentario,
            DateTime? fechaCreacion
        ): base( id )
        {
            HabitacionId = habitacionId;
            ReservaId = reservaId;
            UserId = userId;
            Rating = rating;
            Comentario = comentario;
            FechaCreacion = fechaCreacion;

        }

        public Habitaciones.HabitacionId? HabitacionId { get; private set; }
        public ReservaId? ReservaId { get; private set;}
        public Users.UserId? UserId { get; private set; }
        public Rating? Rating { get; private set; }
        public Comentario? Comentario { get; private set; }
        public DateTime? FechaCreacion { get; private set; }

        public static Result<Review> Create(
            Reserva reserva,
            Rating rating,
            Comentario comentario,
            DateTime? fechaCreacion
        )
        {
            if(reserva.Status != ReservaStatus.Completado)
            {
                return Result.Failure<Review>(ReviewErrors.NotEligible);
            }

            var review = new Review(
                ReviewId.New(),
                reserva.HabitacionId!,
                reserva.Id!,
                reserva.UserId!,
                rating,
                comentario,
                fechaCreacion
            );
            review.RaiseDomainEvent(new ReviewCreatedDomainEvent(review.Id!));
            return review;
        }
    }
}
