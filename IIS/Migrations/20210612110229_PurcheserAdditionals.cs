using Microsoft.EntityFrameworkCore.Migrations;

namespace IIS.Migrations
{
    public partial class PurcheserAdditionals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PurchesersAdditionals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurcheserId = table.Column<int>(type: "int", nullable: true),
                    FlightAdditionalsId = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchesersAdditionals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchesersAdditionals_FlightAdditionals_FlightAdditionalsId",
                        column: x => x.FlightAdditionalsId,
                        principalTable: "FlightAdditionals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchesersAdditionals_Purchesers_PurcheserId",
                        column: x => x.PurcheserId,
                        principalTable: "Purchesers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchesersAdditionals_FlightAdditionalsId",
                table: "PurchesersAdditionals",
                column: "FlightAdditionalsId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchesersAdditionals_PurcheserId",
                table: "PurchesersAdditionals",
                column: "PurcheserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchesersAdditionals");
        }
    }
}
