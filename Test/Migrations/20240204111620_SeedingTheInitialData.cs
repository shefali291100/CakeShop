using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.Migrations
{
    public partial class SeedingTheInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cakes",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[] { 1, "Red velvet cake is a red-colored cake with white icing.", "Red velvet cake", 350.0 });

            migrationBuilder.InsertData(
                table: "Cakes",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[] { 2, "Chocolate cake is a dessert made with cocoa or melted chocolate.", "Chocolate Cake", 300.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cakes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cakes",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
