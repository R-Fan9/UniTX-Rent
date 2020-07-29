using Microsoft.EntityFrameworkCore.Migrations;

namespace RentData.Migrations
{
    public partial class ChangeRentCardtoRenterinRentHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentHistories_RentCards_RentCardId",
                table: "RentHistories");

            migrationBuilder.DropIndex(
                name: "IX_RentHistories_RentCardId",
                table: "RentHistories");

            migrationBuilder.DropColumn(
                name: "RentCardId",
                table: "RentHistories");

            migrationBuilder.AddColumn<int>(
                name: "RenterId",
                table: "RentHistories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RentHistories_RenterId",
                table: "RentHistories",
                column: "RenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_RentHistories_Renters_RenterId",
                table: "RentHistories",
                column: "RenterId",
                principalTable: "Renters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentHistories_Renters_RenterId",
                table: "RentHistories");

            migrationBuilder.DropIndex(
                name: "IX_RentHistories_RenterId",
                table: "RentHistories");

            migrationBuilder.DropColumn(
                name: "RenterId",
                table: "RentHistories");

            migrationBuilder.AddColumn<int>(
                name: "RentCardId",
                table: "RentHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RentHistories_RentCardId",
                table: "RentHistories",
                column: "RentCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_RentHistories_RentCards_RentCardId",
                table: "RentHistories",
                column: "RentCardId",
                principalTable: "RentCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
