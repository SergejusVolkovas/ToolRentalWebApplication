using Microsoft.EntityFrameworkCore.Migrations;

namespace ToolRentalWebApplication.Data.Migrations
{
    public partial class FixingNameOfNamespaces : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Branches",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Branches");
        }
    }
}
