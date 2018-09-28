using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Monona.Data.Migrations
{
    public partial class GoogleCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GoogleCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Enabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoogleCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Name",
                table: "GoogleCategories",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Enabled",
                table: "GoogleCategories",
                columns: new[] { "Enabled", "Name" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GoogleCategories");
        }
    }
}
