using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AirTravelBooking.Server.Data.Migrations
{
    public partial class AddedDefaultDataAndUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Destinations");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Destinations",
                newName: "BoardingName");

            migrationBuilder.AddColumn<string>(
                name: "ArrivallName",
                table: "Destinations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Arrival",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Boarding",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<double>(
                name: "Weight",
                table: "Baggages",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.InsertData(
                table: "Features",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Blank" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "ArrivallName",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "Arrival",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Boarding",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "BoardingName",
                table: "Destinations",
                newName: "Name");

            migrationBuilder.AddColumn<DateTime>(
                name: "Duration",
                table: "Destinations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<float>(
                name: "Weight",
                table: "Baggages",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
