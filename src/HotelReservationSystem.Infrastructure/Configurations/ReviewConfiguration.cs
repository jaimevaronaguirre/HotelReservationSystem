using HotelReservationSystem.Domain.Habitaciones;
using HotelReservationSystem.Domain.Reservas;
using HotelReservationSystem.Domain.Reviews;
using HotelReservationSystem.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelReservationSystem.Infrastructure.Configurations
{
    internal sealed class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("Review");

            builder.HasKey(review => review.Id);

            builder.Property(review => review.Id)
            .HasConversion(reviewId => reviewId!.Value, value => new ReviewId(value));

            builder.Property(review => review.Rating)
            .HasConversion(rating => rating!.Value, value => Rating.Create(value).Value);

            builder.Property(review => review.Comentario)
            .HasMaxLength(200)
            .HasConversion(comentario => comentario!.Value, value => new Comentario(value));

            builder.HasOne<Habitacion>()
            .WithMany()
            .HasForeignKey(review => review.HabitacionId);

            builder.HasOne<Reserva>()
           .WithMany()
           .HasForeignKey(review => review.ReservaId);

            builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(review => review.UserId);
        }
    }
}
