using Microsoft.EntityFrameworkCore.Migrations;

namespace IIS.Migrations
{
    public partial class BaseModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "deleted",
                table: "Users",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "deleted",
                table: "Tickets",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Tickets",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "deleted",
                table: "Flights",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Flights",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "deleted",
                table: "FlightAdditionals",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "FlightAdditionals",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "deleted",
                table: "Destinations",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Destinations",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "deleted",
                table: "Countries",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Countries",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "deleted",
                table: "Cities",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Cities",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "deleted",
                table: "Airports",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Airports",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "deleted",
                table: "Airplanes",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Airplanes",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "Users",
                newName: "deleted");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "Tickets",
                newName: "deleted");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tickets",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "Flights",
                newName: "deleted");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Flights",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "FlightAdditionals",
                newName: "deleted");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "FlightAdditionals",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "Destinations",
                newName: "deleted");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Destinations",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "Countries",
                newName: "deleted");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Countries",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "Cities",
                newName: "deleted");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cities",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "Airports",
                newName: "deleted");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Airports",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "Airplanes",
                newName: "deleted");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Airplanes",
                newName: "id");
        }
    }
}
