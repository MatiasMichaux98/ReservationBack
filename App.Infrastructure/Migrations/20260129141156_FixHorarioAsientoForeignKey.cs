using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixHorarioAsientoForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_asientos_salas_IdSala",
                table: "asientos");

            migrationBuilder.DropForeignKey(
                name: "FK_horarioAsientos_asientos_IdHorario",
                table: "horarioAsientos");

            migrationBuilder.DropForeignKey(
                name: "FK_horarioAsientos_horarios_IdHorario",
                table: "horarioAsientos");

            migrationBuilder.DropForeignKey(
                name: "FK_horarios_peliculas_IdPelicula",
                table: "horarios");

            migrationBuilder.DropForeignKey(
                name: "FK_horarios_salas_IdSala",
                table: "horarios");

            migrationBuilder.DropForeignKey(
                name: "FK_peliculas_generos_GeneroID",
                table: "peliculas");

            migrationBuilder.DropForeignKey(
                name: "FK_reservaciones_asientos_IdHorario",
                table: "reservaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_reservaciones_horarios_IdHorario",
                table: "reservaciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_salas",
                table: "salas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_reservaciones",
                table: "reservaciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_peliculas",
                table: "peliculas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_horarios",
                table: "horarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_horarioAsientos",
                table: "horarioAsientos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_generos",
                table: "generos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_asientos",
                table: "asientos");

            migrationBuilder.RenameTable(
                name: "salas",
                newName: "Salas");

            migrationBuilder.RenameTable(
                name: "reservaciones",
                newName: "Reservaciones");

            migrationBuilder.RenameTable(
                name: "peliculas",
                newName: "Peliculas");

            migrationBuilder.RenameTable(
                name: "horarios",
                newName: "Horarios");

            migrationBuilder.RenameTable(
                name: "horarioAsientos",
                newName: "HorarioAsientos");

            migrationBuilder.RenameTable(
                name: "generos",
                newName: "Generos");

            migrationBuilder.RenameTable(
                name: "asientos",
                newName: "Asientos");

            migrationBuilder.RenameIndex(
                name: "IX_reservaciones_IdHorario",
                table: "Reservaciones",
                newName: "IX_Reservaciones_IdHorario");

            migrationBuilder.RenameIndex(
                name: "IX_peliculas_GeneroID",
                table: "Peliculas",
                newName: "IX_Peliculas_GeneroID");

            migrationBuilder.RenameIndex(
                name: "IX_horarios_IdSala",
                table: "Horarios",
                newName: "IX_Horarios_IdSala");

            migrationBuilder.RenameIndex(
                name: "IX_horarios_IdPelicula",
                table: "Horarios",
                newName: "IX_Horarios_IdPelicula");

            migrationBuilder.RenameIndex(
                name: "IX_horarioAsientos_IdHorario",
                table: "HorarioAsientos",
                newName: "IX_HorarioAsientos_IdHorario");

            migrationBuilder.RenameIndex(
                name: "IX_asientos_IdSala",
                table: "Asientos",
                newName: "IX_Asientos_IdSala");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Salas",
                table: "Salas",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservaciones",
                table: "Reservaciones",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Peliculas",
                table: "Peliculas",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Horarios",
                table: "Horarios",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HorarioAsientos",
                table: "HorarioAsientos",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Generos",
                table: "Generos",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Asientos",
                table: "Asientos",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_HorarioAsientos_IdAsiento",
                table: "HorarioAsientos",
                column: "IdAsiento");

            migrationBuilder.AddForeignKey(
                name: "FK_Asientos_Salas_IdSala",
                table: "Asientos",
                column: "IdSala",
                principalTable: "Salas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HorarioAsientos_Asientos_IdAsiento",
                table: "HorarioAsientos",
                column: "IdAsiento",
                principalTable: "Asientos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HorarioAsientos_Horarios_IdHorario",
                table: "HorarioAsientos",
                column: "IdHorario",
                principalTable: "Horarios",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Horarios_Peliculas_IdPelicula",
                table: "Horarios",
                column: "IdPelicula",
                principalTable: "Peliculas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Horarios_Salas_IdSala",
                table: "Horarios",
                column: "IdSala",
                principalTable: "Salas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Peliculas_Generos_GeneroID",
                table: "Peliculas",
                column: "GeneroID",
                principalTable: "Generos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservaciones_Asientos_IdHorario",
                table: "Reservaciones",
                column: "IdHorario",
                principalTable: "Asientos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservaciones_Horarios_IdHorario",
                table: "Reservaciones",
                column: "IdHorario",
                principalTable: "Horarios",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asientos_Salas_IdSala",
                table: "Asientos");

            migrationBuilder.DropForeignKey(
                name: "FK_HorarioAsientos_Asientos_IdAsiento",
                table: "HorarioAsientos");

            migrationBuilder.DropForeignKey(
                name: "FK_HorarioAsientos_Horarios_IdHorario",
                table: "HorarioAsientos");

            migrationBuilder.DropForeignKey(
                name: "FK_Horarios_Peliculas_IdPelicula",
                table: "Horarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Horarios_Salas_IdSala",
                table: "Horarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Peliculas_Generos_GeneroID",
                table: "Peliculas");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservaciones_Asientos_IdHorario",
                table: "Reservaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservaciones_Horarios_IdHorario",
                table: "Reservaciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Salas",
                table: "Salas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservaciones",
                table: "Reservaciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Peliculas",
                table: "Peliculas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Horarios",
                table: "Horarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HorarioAsientos",
                table: "HorarioAsientos");

            migrationBuilder.DropIndex(
                name: "IX_HorarioAsientos_IdAsiento",
                table: "HorarioAsientos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Generos",
                table: "Generos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Asientos",
                table: "Asientos");

            migrationBuilder.RenameTable(
                name: "Salas",
                newName: "salas");

            migrationBuilder.RenameTable(
                name: "Reservaciones",
                newName: "reservaciones");

            migrationBuilder.RenameTable(
                name: "Peliculas",
                newName: "peliculas");

            migrationBuilder.RenameTable(
                name: "Horarios",
                newName: "horarios");

            migrationBuilder.RenameTable(
                name: "HorarioAsientos",
                newName: "horarioAsientos");

            migrationBuilder.RenameTable(
                name: "Generos",
                newName: "generos");

            migrationBuilder.RenameTable(
                name: "Asientos",
                newName: "asientos");

            migrationBuilder.RenameIndex(
                name: "IX_Reservaciones_IdHorario",
                table: "reservaciones",
                newName: "IX_reservaciones_IdHorario");

            migrationBuilder.RenameIndex(
                name: "IX_Peliculas_GeneroID",
                table: "peliculas",
                newName: "IX_peliculas_GeneroID");

            migrationBuilder.RenameIndex(
                name: "IX_Horarios_IdSala",
                table: "horarios",
                newName: "IX_horarios_IdSala");

            migrationBuilder.RenameIndex(
                name: "IX_Horarios_IdPelicula",
                table: "horarios",
                newName: "IX_horarios_IdPelicula");

            migrationBuilder.RenameIndex(
                name: "IX_HorarioAsientos_IdHorario",
                table: "horarioAsientos",
                newName: "IX_horarioAsientos_IdHorario");

            migrationBuilder.RenameIndex(
                name: "IX_Asientos_IdSala",
                table: "asientos",
                newName: "IX_asientos_IdSala");

            migrationBuilder.AddPrimaryKey(
                name: "PK_salas",
                table: "salas",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_reservaciones",
                table: "reservaciones",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_peliculas",
                table: "peliculas",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_horarios",
                table: "horarios",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_horarioAsientos",
                table: "horarioAsientos",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_generos",
                table: "generos",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_asientos",
                table: "asientos",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_asientos_salas_IdSala",
                table: "asientos",
                column: "IdSala",
                principalTable: "salas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_horarioAsientos_asientos_IdHorario",
                table: "horarioAsientos",
                column: "IdHorario",
                principalTable: "asientos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_horarioAsientos_horarios_IdHorario",
                table: "horarioAsientos",
                column: "IdHorario",
                principalTable: "horarios",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_horarios_peliculas_IdPelicula",
                table: "horarios",
                column: "IdPelicula",
                principalTable: "peliculas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_horarios_salas_IdSala",
                table: "horarios",
                column: "IdSala",
                principalTable: "salas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_peliculas_generos_GeneroID",
                table: "peliculas",
                column: "GeneroID",
                principalTable: "generos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_reservaciones_asientos_IdHorario",
                table: "reservaciones",
                column: "IdHorario",
                principalTable: "asientos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_reservaciones_horarios_IdHorario",
                table: "reservaciones",
                column: "IdHorario",
                principalTable: "horarios",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
