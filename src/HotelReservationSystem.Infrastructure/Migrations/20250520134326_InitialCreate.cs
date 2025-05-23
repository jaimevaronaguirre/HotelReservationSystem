using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelReservationSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Habitacion",
                columns: table => new
                {
                    HabitacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoHabitacion = table.Column<int>(type: "int", nullable: true),
                    UbicacionPiso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UbicacionNumeroPuerta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UbicacionVista = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UbicacionDescripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<int>(type: "int", nullable: true),
                    PrecioReserva_Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PrecioReserva = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServicioAdicional_Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ServicioAdicional = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaUltimaReserva = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CapacidadValor = table.Column<int>(type: "int", nullable: true),
                    Accesorios = table.Column<string>(type: "int", nullable: false),
                    Version = table.Column<long>(type: "bigint", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitacion", x => x.HabitacionId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HabitacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrecioPorNoche_Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PrecioPorNoche = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServicioAdicional_Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ServicioAdicional = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccesoriosHabitacion_Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AccesoriosHabitacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrecioTotal_Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PrecioTotal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DuracionInicio = table.Column<DateOnly>(type: "date", nullable: true),
                    DuracionFin = table.Column<DateOnly>(type: "date", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaConfirmacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaDenegacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaCompletado = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaCancelacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reserva_Habitacion_HabitacionId",
                        column: x => x.HabitacionId,
                        principalTable: "Habitacion",
                        principalColumn: "HabitacionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reserva_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HabitacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReservaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    Comentario = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Review_Habitacion_HabitacionId",
                        column: x => x.HabitacionId,
                        principalTable: "Habitacion",
                        principalColumn: "HabitacionId");
                    table.ForeignKey(
                        name: "FK_Review_Reserva_ReservaId",
                        column: x => x.ReservaId,
                        principalTable: "Reserva",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Review_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_HabitacionId",
                table: "Reserva",
                column: "HabitacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_UserId",
                table: "Reserva",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_HabitacionId",
                table: "Review",
                column: "HabitacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_ReservaId",
                table: "Review",
                column: "ReservaId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_UserId",
                table: "Review",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "Habitacion");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
