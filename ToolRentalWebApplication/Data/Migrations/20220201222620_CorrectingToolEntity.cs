using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToolRentalWebApplication.Data.Migrations
{
    public partial class CorrectingToolEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PricePerDayMaxFiveDays",
                table: "Tools");

            migrationBuilder.DropColumn(
                name: "PricePerDayOverSixDays",
                table: "Tools");

            migrationBuilder.AlterColumn<decimal>(
                name: "PricePerHour",
                table: "Tools",
                type: "decimal(8,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(4,2)");

            migrationBuilder.AddColumn<decimal>(
                name: "PricePerDay",
                table: "Tools",
                type: "decimal(8,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReservationDay",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ReservationEndDay",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "RentDay",
                table: "Rentals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ReturnDay",
                table: "Rentals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PricePerDay",
                table: "Tools");

            migrationBuilder.DropColumn(
                name: "ReservationDay",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ReservationEndDay",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "RentDay",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "ReturnDay",
                table: "Rentals");

            migrationBuilder.AlterColumn<decimal>(
                name: "PricePerHour",
                table: "Tools",
                type: "decimal(4,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,2)");

            migrationBuilder.AddColumn<decimal>(
                name: "PricePerDayMaxFiveDays",
                table: "Tools",
                type: "decimal(4,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PricePerDayOverSixDays",
                table: "Tools",
                type: "decimal(4,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
