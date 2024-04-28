using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace apiconcesionario.Migrations
{
    /// <inheritdoc />
    public partial class IntentodeHasDataMarca2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Marca",
                columns: new[] { "Id", "Image", "Nombre" },
                values: new object[,]
                {
                    { 2, "https://static.vecteezy.com/system/resources/previews/020/502/740/original/mazda-logo-symbol-brand-car-with-name-black-design-japan-automobile-illustration-free-vector.jpg", "Mazda" },
                    { 3, "https://upload.wikimedia.org/wikipedia/commons/thumb/6/60/Bugatti_logo.svg/2560px-Bugatti_logo.svg.png", "Bugatti" },
                    { 4, "https://w7.pngwing.com/pngs/492/427/png-transparent-audi-logo-audi-r8-car-logo-audi-text-trademark-desktop-wallpaper.png", "Audi" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Marca",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Marca",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Marca",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
