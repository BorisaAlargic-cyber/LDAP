using Microsoft.EntityFrameworkCore.Migrations;

namespace IIS.Migrations
{
    public partial class UpdateSearch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FromId",
                table: "Tickets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ToId",
                table: "Tickets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_FromId",
                table: "Tickets",
                column: "FromId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ToId",
                table: "Tickets",
                column: "ToId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Destinations_FromId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Destinations_ToId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_FromId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ToId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "FromId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ToId",
                table: "Tickets");
        }
    }
}
