using Microsoft.EntityFrameworkCore.Migrations;

namespace AirTravelBooking.Server.Data.Migrations
{
    public partial class AddApplicationTables2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ArrivallName",
                table: "Destinations",
                newName: "ArrivalName");

            migrationBuilder.InsertData(
                table: "Baggages",
                columns: new[] { "Id", "Name", "Size", "Weight" },
                values: new object[] { 1, "Example", "Medium", 2.5 });

            migrationBuilder.InsertData(
                table: "Destinations",
                columns: new[] { "Id", "ArrivalName", "BoardingName", "Distance" },
                values: new object[] { 1, "Arrival Airport", "Boarding Airport", 0 });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Availability", "Location" },
                values: new object[] { 1, "Choose a seat", "Not Chosen" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Baggages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "ArrivalName",
                table: "Destinations",
                newName: "ArrivallName");
        }
    }
}
