using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiPrimerWebApi.Migrations
{
    /// <inheritdoc />
    public partial class Biblioteca_UpdateAutor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaNacimiento",
                table: "Autores",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaNacimiento",
                table: "Autores");
        }
    }
}
