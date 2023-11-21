using Microsoft.EntityFrameworkCore.Migrations;

namespace IIS.Migrations
{
    public partial class ticketChangen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Destinations_FromId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Destinations_ToId",
                table: "Tickets");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Airports_FromId",
                table: "Tickets",
                column: "FromId",
                principalTable: "Airports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Airports_ToId",
                table: "Tickets",
                column: "ToId",
                principalTable: "Airports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Airports_FromId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Airports_ToId",
                table: "Tickets");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Destinations_FromId",
                table: "Tickets",
                column: "FromId",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Destinations_ToId",
                table: "Tickets",
                column: "ToId",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
