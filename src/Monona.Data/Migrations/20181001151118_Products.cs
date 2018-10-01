using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Monona.Data.Migrations
{
    public partial class Products : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StoreId = table.Column<int>(nullable: false),
                    VendorId = table.Column<int>(nullable: false),
                    VendorPartNumber = table.Column<string>(maxLength: 64, nullable: true),
                    Sku = table.Column<string>(maxLength: 64, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    CasePack = table.Column<int>(nullable: false),
                    ReorderPoint = table.Column<int>(nullable: false),
                    WarehouseLocation = table.Column<string>(maxLength: 256, nullable: true),
                    BulkWarehouseLocation = table.Column<string>(maxLength: 256, nullable: true),
                    LeadDays = table.Column<int>(nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    MaxLength = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    BoxSize = table.Column<string>(maxLength: 256, nullable: true),
                    Dropshipped = table.Column<bool>(nullable: false),
                    Seasonal = table.Column<bool>(nullable: false),
                    DisallowBackorder = table.Column<bool>(nullable: false),
                    Discontinued = table.Column<bool>(nullable: false),
                    NotInStoresExclude = table.Column<bool>(nullable: false),
                    CountryOfOriginId = table.Column<int>(nullable: true),
                    GoogleCategoryId = table.Column<int>(nullable: true),
                    Gtin = table.Column<string>(maxLength: 64, nullable: true),
                    Brand = table.Column<string>(maxLength: 256, nullable: true),
                    Mpn = table.Column<string>(maxLength: 64, nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    LastPrintedOn = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Countries_CountryOfOriginId",
                        column: x => x.CountryOfOriginId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_GoogleCategories_GoogleCategoryId",
                        column: x => x.GoogleCategoryId,
                        principalTable: "GoogleCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductInventory",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    StockQuantity = table.Column<int>(nullable: false),
                    ReservedQuantity = table.Column<int>(nullable: false),
                    AvailableQuantity = table.Column<int>(nullable: false),
                    PoQuantity = table.Column<int>(nullable: false),
                    PotentialQuantity = table.Column<int>(nullable: false),
                    NextPoOn = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInventory", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_ProductInventory_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CountryOfOriginId",
                table: "Products",
                column: "CountryOfOriginId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_GoogleCategoryId",
                table: "Products",
                column: "GoogleCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Name",
                table: "Products",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "UX_Sku",
                table: "Products",
                column: "Sku",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_StoreId",
                table: "Products",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_VendorId",
                table: "Products",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseLocation",
                table: "Products",
                column: "WarehouseLocation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductInventory");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
