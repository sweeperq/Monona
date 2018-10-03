using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Monona.Data.Migrations
{
    public partial class Adjustments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adjustments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdjustmentTypeId = table.Column<int>(nullable: false),
                    StoreId = table.Column<int>(nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    ReferenceNumber = table.Column<string>(maxLength: 256, nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    AdjustmentDate = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adjustments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adjustments_AdjustmentTypes_AdjustmentTypeId",
                        column: x => x.AdjustmentTypeId,
                        principalTable: "AdjustmentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Adjustments_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Adjustments_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adjustments_AdjustmentTypeId",
                table: "Adjustments",
                column: "AdjustmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ReferenceNumber",
                table: "Adjustments",
                column: "ReferenceNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Adjustments_StoreId",
                table: "Adjustments",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAdjustmentsByDate",
                table: "Adjustments",
                columns: new[] { "ProductId", "AdjustmentDate", "AdjustmentTypeId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adjustments");
        }
    }
}
