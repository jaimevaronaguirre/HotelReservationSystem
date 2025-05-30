﻿// <auto-generated />
using System;
using HotelReservationSystem.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelReservationSystem.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250520163208_ActualizarMigracion")]
    partial class ActualizarMigracion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HotelReservationSystem.Domain.Habitaciones.Habitacion", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("HabitacionId");

                    b.PrimitiveCollection<string>("Accesorios")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Estado")
                        .HasColumnType("int")
                        .HasColumnName("Estado");

                    b.Property<DateTime?>("FechaUltimaReserva")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TipoHabitacion")
                        .HasColumnType("int")
                        .HasColumnName("TipoHabitacion");

                    b.Property<long>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Habitacion", (string)null);
                });

            modelBuilder.Entity("HotelReservationSystem.Domain.Reservas.Reserva", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("FechaCancelacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaCompletado")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaConfirmacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaDenegacion")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("HabitacionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("HabitacionId");

                    b.HasIndex("UserId");

                    b.ToTable("Reserva", (string)null);
                });

            modelBuilder.Entity("HotelReservationSystem.Domain.Reviews.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comentario")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("HabitacionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.Property<Guid?>("ReservaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("HabitacionId");

                    b.HasIndex("ReservaId");

                    b.HasIndex("UserId");

                    b.ToTable("Review", (string)null);
                });

            modelBuilder.Entity("HotelReservationSystem.Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Apellido");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)")
                        .HasColumnName("Email");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Nombre");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasColumnName("PasswordHash");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("HotelReservationSystem.Domain.Habitaciones.Habitacion", b =>
                {
                    b.OwnsOne("HotelReservationSystem.Domain.Habitaciones.Capacidad", "Capacidad", b1 =>
                        {
                            b1.Property<Guid>("HabitacionId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Valor")
                                .HasColumnType("int")
                                .HasColumnName("Capacidad");

                            b1.HasKey("HabitacionId");

                            b1.ToTable("Habitacion");

                            b1.WithOwner()
                                .HasForeignKey("HabitacionId");
                        });

                    b.OwnsOne("HotelReservationSystem.Domain.Shared.Moneda", "PrecioReserva", b1 =>
                        {
                            b1.Property<Guid>("HabitacionId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Monto")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<string>("TipoMoneda")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("HabitacionId");

                            b1.ToTable("Habitacion");

                            b1.WithOwner()
                                .HasForeignKey("HabitacionId");
                        });

                    b.OwnsOne("HotelReservationSystem.Domain.Shared.Moneda", "ServicioAdicional", b1 =>
                        {
                            b1.Property<Guid>("HabitacionId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Monto")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<string>("TipoMoneda")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("HabitacionId");

                            b1.ToTable("Habitacion");

                            b1.WithOwner()
                                .HasForeignKey("HabitacionId");
                        });

                    b.OwnsOne("HotelReservationSystem.Domain.Habitaciones.Ubicacion", "Ubicacion", b1 =>
                        {
                            b1.Property<Guid>("HabitacionId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("DescripcionAdicional")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("UbicacionDescripcion");

                            b1.Property<string>("NumeroPuerta")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("UbicacionNumeroPuerta");

                            b1.Property<string>("Piso")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("UbicacionPiso");

                            b1.Property<string>("Vista")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("UbicacionVista");

                            b1.HasKey("HabitacionId");

                            b1.ToTable("Habitacion");

                            b1.WithOwner()
                                .HasForeignKey("HabitacionId");
                        });

                    b.Navigation("Capacidad");

                    b.Navigation("PrecioReserva");

                    b.Navigation("ServicioAdicional");

                    b.Navigation("Ubicacion");
                });

            modelBuilder.Entity("HotelReservationSystem.Domain.Reservas.Reserva", b =>
                {
                    b.HasOne("HotelReservationSystem.Domain.Habitaciones.Habitacion", null)
                        .WithMany()
                        .HasForeignKey("HabitacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelReservationSystem.Domain.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("HotelReservationSystem.Domain.Reservas.DateRange", "Duracion", b1 =>
                        {
                            b1.Property<Guid>("ReservaId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateOnly>("Fin")
                                .HasColumnType("date")
                                .HasColumnName("DuracionFin");

                            b1.Property<DateOnly>("Inicio")
                                .HasColumnType("date")
                                .HasColumnName("DuracionInicio");

                            b1.HasKey("ReservaId");

                            b1.ToTable("Reserva");

                            b1.WithOwner()
                                .HasForeignKey("ReservaId");
                        });

                    b.OwnsOne("HotelReservationSystem.Domain.Shared.Moneda", "AccesoriosHabitacion", b1 =>
                        {
                            b1.Property<Guid>("ReservaId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Monto")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<string>("TipoMoneda")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("AccesoriosHabitacion");

                            b1.HasKey("ReservaId");

                            b1.ToTable("Reserva");

                            b1.WithOwner()
                                .HasForeignKey("ReservaId");
                        });

                    b.OwnsOne("HotelReservationSystem.Domain.Shared.Moneda", "PrecioPorNoche", b1 =>
                        {
                            b1.Property<Guid>("ReservaId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Monto")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<string>("TipoMoneda")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("PrecioPorNoche");

                            b1.HasKey("ReservaId");

                            b1.ToTable("Reserva");

                            b1.WithOwner()
                                .HasForeignKey("ReservaId");
                        });

                    b.OwnsOne("HotelReservationSystem.Domain.Shared.Moneda", "PrecioTotal", b1 =>
                        {
                            b1.Property<Guid>("ReservaId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Monto")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<string>("TipoMoneda")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("PrecioTotal");

                            b1.HasKey("ReservaId");

                            b1.ToTable("Reserva");

                            b1.WithOwner()
                                .HasForeignKey("ReservaId");
                        });

                    b.OwnsOne("HotelReservationSystem.Domain.Shared.Moneda", "ServicioAdicional", b1 =>
                        {
                            b1.Property<Guid>("ReservaId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Monto")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<string>("TipoMoneda")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("ServicioAdicional");

                            b1.HasKey("ReservaId");

                            b1.ToTable("Reserva");

                            b1.WithOwner()
                                .HasForeignKey("ReservaId");
                        });

                    b.Navigation("AccesoriosHabitacion");

                    b.Navigation("Duracion");

                    b.Navigation("PrecioPorNoche");

                    b.Navigation("PrecioTotal");

                    b.Navigation("ServicioAdicional");
                });

            modelBuilder.Entity("HotelReservationSystem.Domain.Reviews.Review", b =>
                {
                    b.HasOne("HotelReservationSystem.Domain.Habitaciones.Habitacion", null)
                        .WithMany()
                        .HasForeignKey("HabitacionId");

                    b.HasOne("HotelReservationSystem.Domain.Reservas.Reserva", null)
                        .WithMany()
                        .HasForeignKey("ReservaId");

                    b.HasOne("HotelReservationSystem.Domain.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
