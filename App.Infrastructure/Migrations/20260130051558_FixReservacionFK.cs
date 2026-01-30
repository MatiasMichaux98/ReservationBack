using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixReservacionFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservaciones_Asientos_IdHorario",
                table: "Reservaciones");

            migrationBuilder.CreateIndex(
                name: "IX_Reservaciones_IdAsiento",
                table: "Reservaciones",
                column: "IdAsiento");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservaciones_Asientos_IdAsiento",
                table: "Reservaciones",
                column: "IdAsiento",
                principalTable: "Asientos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservaciones_Asientos_IdAsiento",
                table: "Reservaciones");

            migrationBuilder.DropIndex(
                name: "IX_Reservaciones_IdAsiento",
                table: "Reservaciones");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservaciones_Asientos_IdHorario",
                table: "Reservaciones",
                column: "IdHorario",
                principalTable: "Asientos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
