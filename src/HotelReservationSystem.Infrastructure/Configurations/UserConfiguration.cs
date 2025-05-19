using HotelReservationSystem.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelReservationSystem.Infrastructure.Configurations
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(
            EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(user => user.Id);

            builder.Property(user => user.Id)
            .HasConversion(userId => userId!.Value, value => new UserId(value));


            builder.Property(user => user.Nombre)
                .HasMaxLength(200)
                .HasConversion(nombre => nombre!.Value, value => new Nombre(value))
                .HasColumnName("Nombre")
                .IsRequired();

            builder.Property(user => user.Apellido)
            .HasMaxLength(200)
            .HasConversion(apellido => apellido!.Value, value => new Apellido(value))
            .HasColumnName("Apellido")
            .IsRequired();

            builder.Property(user => user.Email)
            .HasMaxLength(400)
            .HasConversion(email => email!.Value, value => new Domain.Users.Email(value))
            .HasColumnName("Email")
            .IsRequired();

            builder.Property(user => user.PasswordHash)
            .HasMaxLength(2000)
            .HasConversion(password => password!.Value, value => new PasswordHash(value))
            .HasColumnName("PasswordHash")
            .IsRequired();


            builder.HasIndex(user => user.Email).IsUnique();
        }
    }
}
