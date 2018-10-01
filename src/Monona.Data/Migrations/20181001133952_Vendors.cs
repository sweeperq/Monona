using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Monona.Data.Migrations
{
    public partial class Vendors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Address = table.Column<string>(nullable: true),
                    PoEmailAddresses = table.Column<string>(nullable: true),
                    PaymentTerms = table.Column<string>(nullable: true),
                    StripFromSkuForClient = table.Column<string>(maxLength: 64, nullable: true),
                    DefaultLeadDays = table.Column<int>(nullable: true),
                    DefaultCountryOfOriginId = table.Column<int>(nullable: true),
                    DefaultGoogleCategoryId = table.Column<int>(nullable: true),
                    DefaultBrand = table.Column<string>(maxLength: 256, nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Enabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendors_Countries_DefaultCountryOfOriginId",
                        column: x => x.DefaultCountryOfOriginId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Vendors_GoogleCategories_DefaultGoogleCategoryId",
                        column: x => x.DefaultGoogleCategoryId,
                        principalTable: "GoogleCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_DefaultCountryOfOriginId",
                table: "Vendors",
                column: "DefaultCountryOfOriginId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_DefaultGoogleCategoryId",
                table: "Vendors",
                column: "DefaultGoogleCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Name",
                table: "Vendors",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Enabled",
                table: "Vendors",
                columns: new[] { "Enabled", "Name" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vendors");
        }
    }
}
