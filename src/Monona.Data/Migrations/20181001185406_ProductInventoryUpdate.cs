using Microsoft.EntityFrameworkCore.Migrations;

namespace Monona.Data.Migrations
{
    public partial class ProductInventoryUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PoQuantity",
                table: "ProductInventory",
                newName: "OnOrderQuantity");

            migrationBuilder.CreateIndex(
                name: "IX_StockQuantity",
                table: "ProductInventory",
                columns: new[] { "ProductId", "StockQuantity" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StockQuantity",
                table: "ProductInventory");

            migrationBuilder.RenameColumn(
                name: "OnOrderQuantity",
                table: "ProductInventory",
                newName: "PoQuantity");
        }
    }
}
