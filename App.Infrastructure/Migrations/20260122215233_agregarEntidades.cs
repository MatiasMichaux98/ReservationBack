using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class agregarEntidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AñoLanzamiento",
                table: "peliculas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "peliculas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DuracionMinutos",
                table: "peliculas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GeneroID",
                table: "peliculas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Imagen",
                table: "peliculas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "generos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_generos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "salas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "asientos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroAsiento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdSala = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asientos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_asientos_salas_IdSala",
                        column: x => x.IdSala,
                        principalTable: "salas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "horarios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPelicula = table.Column<int>(type: "int", nullable: false),
                    IdSala = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    HoraInicio = table.Column<TimeOnly>(type: "time", nullable: false),
                    HoraFinal = table.Column<TimeOnly>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_horarios", x => x.ID);
                    table.ForeignKey(
                        name: "FK_horarios_peliculas_IdPelicula",
                        column: x => x.IdPelicula,
                        principalTable: "peliculas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_horarios_salas_IdSala",
                        column: x => x.IdSala,
                        principalTable: "salas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "horarioAsientos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdHorario = table.Column<int>(type: "int", nullable: false),
                    IdAsiento = table.Column<int>(type: "int", nullable: false),
                    IsReserved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_horarioAsientos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_horarioAsientos_asientos_IdHorario",
                        column: x => x.IdHorario,
                        principalTable: "asientos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_horarioAsientos_horarios_IdHorario",
                        column: x => x.IdHorario,
                        principalTable: "horarios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "reservaciones",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdHorario = table.Column<int>(type: "int", nullable: false),
                    IdAsiento = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estadoReserva = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservaciones", x => x.ID);
                    table.ForeignKey(
                        name: "FK_reservaciones_asientos_IdHorario",
                        column: x => x.IdHorario,
                        principalTable: "asientos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_reservaciones_horarios_IdHorario",
                        column: x => x.IdHorario,
                        principalTable: "horarios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "generos",
                columns: new[] { "ID", "Nombre" },
                values: new object[,]
                {
                    { 1, "Accion" },
                    { 2, "Aventura" },
                    { 3, "Comedia" },
                    { 4, "Drama" },
                    { 5, "Terror" },
                    { 6, "Romance" },
                    { 7, "Fantasía" },
                    { 8, "Musical" },
                    { 9, "Suspenso " },
                    { 10, "Ciencia Ficción" }
                });

            migrationBuilder.InsertData(
                table: "salas",
                columns: new[] { "ID", "Nombre" },
                values: new object[,]
                {
                    { 1, "Sala 1" },
                    { 2, "Sala 2" }
                });

            migrationBuilder.InsertData(
                table: "asientos",
                columns: new[] { "ID", "IdSala", "NumeroAsiento" },
                values: new object[,]
                {
                    { 1, 1, "A1" },
                    { 2, 1, "A2" },
                    { 3, 1, "A3" },
                    { 4, 1, "A4" },
                    { 5, 1, "A5" },
                    { 6, 2, "B6" },
                    { 7, 2, "B7" },
                    { 8, 2, "B8" },
                    { 9, 2, "B9" },
                    { 10, 2, "B10" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_peliculas_GeneroID",
                table: "peliculas",
                column: "GeneroID");

            migrationBuilder.CreateIndex(
                name: "IX_asientos_IdSala",
                table: "asientos",
                column: "IdSala");

            migrationBuilder.CreateIndex(
                name: "IX_horarioAsientos_IdHorario",
                table: "horarioAsientos",
                column: "IdHorario");

            migrationBuilder.CreateIndex(
                name: "IX_horarios_IdPelicula",
                table: "horarios",
                column: "IdPelicula");

            migrationBuilder.CreateIndex(
                name: "IX_horarios_IdSala",
                table: "horarios",
                column: "IdSala");

            migrationBuilder.CreateIndex(
                name: "IX_reservaciones_IdHorario",
                table: "reservaciones",
                column: "IdHorario");

            migrationBuilder.AddForeignKey(
                name: "FK_peliculas_generos_GeneroID",
                table: "peliculas",
                column: "GeneroID",
                principalTable: "generos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_peliculas_generos_GeneroID",
                table: "peliculas");

            migrationBuilder.DropTable(
                name: "generos");

            migrationBuilder.DropTable(
                name: "horarioAsientos");

            migrationBuilder.DropTable(
                name: "reservaciones");

            migrationBuilder.DropTable(
                name: "asientos");

            migrationBuilder.DropTable(
                name: "horarios");

            migrationBuilder.DropTable(
                name: "salas");

            migrationBuilder.DropIndex(
                name: "IX_peliculas_GeneroID",
                table: "peliculas");

            migrationBuilder.DropColumn(
                name: "AñoLanzamiento",
                table: "peliculas");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "peliculas");

            migrationBuilder.DropColumn(
                name: "DuracionMinutos",
                table: "peliculas");

            migrationBuilder.DropColumn(
                name: "GeneroID",
                table: "peliculas");

            migrationBuilder.DropColumn(
                name: "Imagen",
                table: "peliculas");
        }
    }
}
