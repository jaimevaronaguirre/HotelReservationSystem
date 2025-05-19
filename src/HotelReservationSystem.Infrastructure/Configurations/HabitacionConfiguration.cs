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

            // ==== TipoHabitacion ====
            builder.Property(h => h.Id)
                .HasColumnName("HabitacionId")
                .HasConversion(id => id!.Value, value => new HabitacionId(value));

            // ==== TipoHabitacion ====
            builder.Property(h => h.TipoHabitacion)
                .HasColumnName("TipoHabitacion")
                .HasConversion<int>(); // Enum como entero

            // ==== Estado ====
            builder.Property(h => h.Estado)
                .HasColumnName("Estado")
                .HasConversion<int>(); // Enum como entero

            builder.Property<uint>("Version")
                .IsRowVersion();

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

            // ==== PrecioReserva ====
            builder.OwnsOne(h => h.PrecioReserva, precio =>
            {
                precio.Property(p => p.TipoMoneda)
                    .HasColumnName("PrecioReserva")
                    .HasConversion(
                        tm => tm.Codigo,
                        codigo => TipoMoneda.FromCodigo(codigo!)
                    );
            });

            // ==== ServicioAdicional ====
            builder.OwnsOne(h => h.ServicioAdicional, servicio =>
            {
                servicio.Property(s => s.TipoMoneda)
                    .HasColumnName("ServicioAdicional")
                    .HasConversion(
                        tm => tm.Codigo,
                        codigo => TipoMoneda.FromCodigo(codigo!)
                    );
            });

            // ==== Capacidad ====
            builder.OwnsOne(h => h.Capacidad, capacidad =>
            {
                capacidad.Property(c => c.Valor)
                    .HasColumnName("CapacidadValor")
                    .IsRequired();
            });

            builder.Property<uint>("Version").IsRowVersion();
        }
    }
}


