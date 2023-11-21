using Microsoft.EntityFrameworkCore.Migrations;

namespace IIS.Migrations
{
    public partial class destination : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "destinationId",
                table: "Airports",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Airports_destinationId",
                table: "Airports",
                column: "destinationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Airports_Destinations_destinationId",
                table: "Airports",
                column: "destinationId",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Airports_Destinations_destinationId",
                table: "Airports");

            migrationBuilder.DropIndex(
                name: "IX_Airports_destinationId",
                table: "Airports");

            migrationBuilder.DropColumn(
                name: "destinationId",
                table: "Airports");
        }
    }
}
