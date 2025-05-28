using HotelReservationSystem.Domain.Habitaciones;
using HotelReservationSystem.Domain.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelReservationSystem.Infrastructure.Configurations
{
    internal sealed class HabitacionConfiguration : IEntityTypeConfiguration<Habitacion>
    {
        public void Configure(EntityTypeBuilder<Habitacion> builder)
        {
            builder.ToTable("Habitacion");
            builder.HasKey(h => h.Id);

            // ==== IdHabitacion ====
            builder.Property(h => h.Id)
                .HasColumnName("HabitacionId")
                .HasConversion(id => id!.Value, value => new HabitacionId(value));

            // ==== Ubicación ====
            builder.OwnsOne(h => h.Ubicacion, ubicacion =>
            {
                ubicacion.Property(u => u.Piso)
                    .HasColumnName("UbicacionPiso")
                    .IsRequired();

                ubicacion.Property(u => u.NumeroPuerta)
                    .HasColumnName("UbicacionNumeroPuerta")
                    .IsRequired();

                ubicacion.Property(u => u.Vista)
                    .HasColumnName("UbicacionVista");

                ubicacion.Property(u => u.DescripcionAdicional)
                    .HasColumnName("UbicacionDescripcion");
            });

            // ==== TipoHabitacion ====
            builder.Property(h => h.TipoHabitacion)
                .HasColumnName("TipoHabitacion")
                .HasConversion<int>(); // Enum como entero

            // ==== Estado ====
            builder.Property(h => h.Estado)
                .HasColumnName("Estado")
                .HasConversion<int>(); // Enum como entero


            // ==== PrecioReserva ====
            builder.OwnsOne(h => h.PrecioReserva, precio => {
                precio.Property(moneda => moneda.TipoMoneda)
                .HasPrecision(18, 4) // Ajusta según tus necesidades
                .HasConversion(tipoMoneda => tipoMoneda.Codigo, codigo => TipoMoneda.FromCodigo(codigo!));
            });

            
            // ==== ServicioAdicional ====
            builder.OwnsOne(habitacion => habitacion.ServicioAdicional, priceBuilder => {
                priceBuilder.Property(moneda => moneda.TipoMoneda)
                .HasPrecision(18, 4) // Ajusta según tus necesidades
                .HasConversion(tipoMoneda => tipoMoneda.Codigo, codigo => TipoMoneda.FromCodigo(codigo!));
            });
            
           
            // ==== Capacidad ====
            builder.OwnsOne(h => h.Capacidad, capacidad =>
            {
                capacidad.Property(c => c.Valor)
                    .HasColumnName("Capacidad")
                    .IsRequired();
            });

            
            builder.Property<uint>("Version").IsRowVersion();
        }
    }
}


