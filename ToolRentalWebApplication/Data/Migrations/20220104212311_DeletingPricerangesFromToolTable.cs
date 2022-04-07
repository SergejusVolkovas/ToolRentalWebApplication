using Microsoft.EntityFrameworkCore.Migrations;

namespace ToolRentalWebApplication.Data.Migrations
{
    public partial class DeletingPricerangesFromToolTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PricePerDayMaxTenDays",
                table: "Tools");

            migrationBuilder.RenameColumn(
                name: "PricePerDayOverTenDays",
                table: "Tools",
                newName: "PricePerDayOverSixDays");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PricePerDayOverSixDays",
                table: "Tools",
                newName: "PricePerDayOverTenDays");

            migrationBuilder.AddColumn<decimal>(
                name: "PricePerDayMaxTenDays",
                table: "Tools",
                type: "decimal(4,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
