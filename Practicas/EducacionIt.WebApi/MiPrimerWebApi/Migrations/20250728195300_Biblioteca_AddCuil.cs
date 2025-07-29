using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiPrimerWebApi.Migrations
{
    /// <inheritdoc />
    public partial class Biblioteca_AddCuil : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cuil",
                table: "Autores",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cuil",
                table: "Autores");
        }
    }
}
