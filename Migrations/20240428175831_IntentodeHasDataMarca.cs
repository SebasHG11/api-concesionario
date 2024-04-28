using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiconcesionario.Migrations
{
    /// <inheritdoc />
    public partial class IntentodeHasDataMarca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Marca",
                columns: new[] { "Id", "Image", "Nombre" },
                values: new object[] { 1, "https://upload.wikimedia.org/wikipedia/commons/1/1e/Chevrolet-logo.png", "Chevrolet" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Marca",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
