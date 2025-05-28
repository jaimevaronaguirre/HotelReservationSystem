using HotelReservationSystem.Domain.Habitaciones;
using HotelReservationSystem.Domain.Reservas;
using HotelReservationSystem.Domain.Shared;
using HotelReservationSystem.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelReservationSystem.Infrastructure.Configurations
{
    internal sealed class ReservaConfiguration : IEntityTypeConfiguration<Reserva>
    {
        public void Configure(EntityTypeBuilder<Reserva> builder)
        {
            builder.ToTable("Reserva");
            builder.HasKey(reserva => reserva.Id);

            builder.Property(reserva => reserva.Id)
                .HasConversion(reservaId => reservaId!.Value, value => new ReservaId(value));

            // === PrecioPorNoche ===
            builder.OwnsOne(reserva => reserva.PrecioPorNoche, precioBuilder =>
            {
                precioBuilder.Property(moneda => moneda.TipoMoneda)
                    .HasConversion(tipoMoneda => tipoMoneda.Codigo, codigo => TipoMoneda.FromCodigo(codigo!))
                    .HasColumnName("PrecioPorNocheTipoMoneda")
                    .IsRequired();

                precioBuilder.Property(moneda => moneda.Monto)
                    .HasPrecision(18, 4)
                    .HasColumnName("PrecioPorNocheMonto")
                    .IsRequired();
            });

            // === ServicioAdicional ===
            builder.OwnsOne(reserva => reserva.ServicioAdicional, precioBuilder =>
            {
                precioBuilder.Property(moneda => moneda.TipoMoneda)
                    .HasConversion(tipoMoneda => tipoMoneda.Codigo, codigo => TipoMoneda.FromCodigo(codigo!))
                    .HasColumnName("ServicioAdicionalTipoMoneda");

                precioBuilder.Property(moneda => moneda.Monto)
                    .HasPrecision(18, 4)
                    .HasColumnName("ServicioAdicionalMonto");
            });

            // === AccesoriosHabitacion ===
            builder.OwnsOne(reserva => reserva.AccesoriosHabitacion, precioBuilder =>
            {
                precioBuilder.Property(moneda => moneda.TipoMoneda)
                    .HasConversion(tipoMoneda => tipoMoneda.Codigo, codigo => TipoMoneda.FromCodigo(codigo!))
                    .HasColumnName("AccesoriosHabitacionTipoMoneda");

                precioBuilder.Property(moneda => moneda.Monto)
                    .HasPrecision(18, 4)
                    .HasColumnName("AccesoriosHabitacionMonto");
            });

            // === PrecioTotal ===
            builder.OwnsOne(reserva => reserva.PrecioTotal, precioBuilder =>
            {
                precioBuilder.Property(moneda => moneda.TipoMoneda)
                    .HasConversion(tipoMoneda => tipoMoneda.Codigo, codigo => TipoMoneda.FromCodigo(codigo!))
                    .HasColumnName("PrecioTotalTipoMoneda")
                    .IsRequired();

                precioBuilder.Property(moneda => moneda.Monto)
                    .HasPrecision(18, 4)
                    .HasColumnName("PrecioTotalMonto")
                    .IsRequired();
            });

            builder.OwnsOne(reserva => reserva.Duracion, duracionBuilder =>
            {
                duracionBuilder.Property(d => d.Inicio)
                    .HasColumnName("DuracionInicio")
                    .IsRequired();

                duracionBuilder.Property(d => d.Fin)
                    .HasColumnName("DuracionFin")
                    .IsRequired();
            });

            builder.HasOne<Habitacion>()
                .WithMany()
                .HasForeignKey(reserva => reserva.HabitacionId)
                .IsRequired();

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(reserva => reserva.UserId)
                .IsRequired();
        }
    }

    //internal sealed class ReservaConfiguration : IEntityTypeConfiguration<Reserva>
    //{
    //    public void Configure(EntityTypeBuilder<Reserva> builder)
    //    {
    //        builder.ToTable("Reserva");
    //        builder.HasKey(reserva => reserva.Id);

    //        builder.Property(reserva => reserva.Id)
    //            .HasConversion(reservaId => reservaId!.Value, value => new ReservaId(value));

    //        builder.OwnsOne(reserva => reserva.PrecioPorNoche, precioBuilder =>
    //        {
    //            precioBuilder.Property(moneda => moneda.TipoMoneda)
    //            .HasConversion(tipoMoneda => tipoMoneda.Codigo, codigo => TipoMoneda.FromCodigo(codigo!))    //            
    //            .HasColumnName("PrecioPorNoche")
    //            .IsRequired(); 
    //        });

    //        builder.OwnsOne(reserva => reserva.ServicioAdicional, precioBuilder =>
    //        {
    //            precioBuilder.Property(moneda => moneda.TipoMoneda)
    //           .HasConversion(tipoMoneda => tipoMoneda.Codigo, codigo => TipoMoneda.FromCodigo(codigo!))    //           
    //           .HasColumnName("ServicioAdicional");                
    //        });


    //        builder.OwnsOne(reserva => reserva.AccesoriosHabitacion, precioBuilder =>
    //        {
    //            precioBuilder.Property(moneda => moneda.TipoMoneda)
    //           .HasConversion(tipoMoneda => tipoMoneda.Codigo, codigo => TipoMoneda.FromCodigo(codigo!))
    //           .HasColumnName("AccesoriosHabitacion");
    //        });

    //        builder.OwnsOne(reserva => reserva.PrecioTotal, precioBuilder =>
    //        {
    //            precioBuilder.Property(moneda => moneda.TipoMoneda)
    //           .HasConversion(tipoMoneda => tipoMoneda.Codigo, codigo => TipoMoneda.FromCodigo(codigo!))
    //           .HasColumnName("PrecioTotal")
    //           .IsRequired();
    //        });

    //        builder.OwnsOne(reserva => reserva.Duracion, duracionBuilder =>
    //        {
    //            duracionBuilder.Property(d => d.Inicio)
    //                .HasColumnName("DuracionInicio")
    //                .IsRequired();

    //            duracionBuilder.Property(d => d.Fin)
    //                .HasColumnName("DuracionFin")
    //                .IsRequired();
    //        });

    //        builder.HasOne<Habitacion>()
    //        .WithMany()
    //        .HasForeignKey(reserva => reserva.HabitacionId)
    //        .IsRequired();

    //        builder.HasOne<User>()
    //       .WithMany()
    //       .HasForeignKey(reserva => reserva.UserId)
    //       .IsRequired();
    //    }
    //}
}
