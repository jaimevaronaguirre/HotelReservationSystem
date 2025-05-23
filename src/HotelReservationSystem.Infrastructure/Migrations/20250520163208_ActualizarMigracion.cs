using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelReservationSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ActualizarMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ServicioAdicional",
                table: "Habitacion",
                newName: "ServicioAdicional_TipoMoneda");

            migrationBuilder.RenameColumn(
                name: "PrecioReserva",
                table: "Habitacion",
                newName: "PrecioReserva_TipoMoneda");

            migrationBuilder.RenameColumn(
                name: "CapacidadValor",
                table: "Habitacion",
                newName: "Capacidad");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ServicioAdicional_TipoMoneda",
                table: "Habitacion",
                newName: "ServicioAdicional");

            migrationBuilder.RenameColumn(
                name: "PrecioReserva_TipoMoneda",
                table: "Habitacion",
                newName: "PrecioReserva");

            migrationBuilder.RenameColumn(
                name: "Capacidad",
                table: "Habitacion",
                newName: "CapacidadValor");
        }
    }
}
