using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiPrimerWebApi.Migrations
{
    /// <inheritdoc />
    public partial class Biblioteca_AddIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Autores_Cuil",
                table: "Autores",
                column: "Cuil",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Autores_Email",
                table: "Autores",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Autores_Cuil",
                table: "Autores");

            migrationBuilder.DropIndex(
                name: "IX_Autores_Email",
                table: "Autores");
        }
    }
}
