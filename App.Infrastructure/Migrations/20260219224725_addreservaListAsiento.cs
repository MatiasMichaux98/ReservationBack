using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addreservaListAsiento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          
            migrationBuilder.CreateTable(
                name: "reservaAsientos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    asientoId = table.Column<int>(type: "int", nullable: false),
                    reservacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservaAsientos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_reservaAsientos_Asientos_asientoId",
                        column: x => x.asientoId,
                        principalTable: "Asientos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_reservaAsientos_Reservaciones_reservacionId",
                        column: x => x.reservacionId,
                        principalTable: "Reservaciones",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_reservaAsientos_asientoId",
                table: "reservaAsientos",
                column: "asientoId");

            migrationBuilder.CreateIndex(
                name: "IX_reservaAsientos_reservacionId",
                table: "reservaAsientos",
                column: "reservacionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reservaAsientos");

            migrationBuilder.AddColumn<int>(
                name: "IdAsiento",
                table: "Reservaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
