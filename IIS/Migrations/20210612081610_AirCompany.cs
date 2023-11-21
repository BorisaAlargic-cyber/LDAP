using Microsoft.EntityFrameworkCore.Migrations;

namespace IIS.Migrations
{
    public partial class AirCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AirCompany",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AirCompany",
                table: "Tickets");
        }
    }
}
