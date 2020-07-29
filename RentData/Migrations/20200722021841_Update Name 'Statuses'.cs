using Microsoft.EntityFrameworkCore.Migrations;

namespace RentData.Migrations
{
    public partial class UpdateNameStatuses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Textbooks_Statuas_StatusId",
                table: "Textbooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Statuas",
                table: "Statuas");

            migrationBuilder.RenameTable(
                name: "Statuas",
                newName: "Statuses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Statuses",
                table: "Statuses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Textbooks_Statuses_StatusId",
                table: "Textbooks",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Textbooks_Statuses_StatusId",
                table: "Textbooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Statuses",
                table: "Statuses");

            migrationBuilder.RenameTable(
                name: "Statuses",
                newName: "Statuas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Statuas",
                table: "Statuas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Textbooks_Statuas_StatusId",
                table: "Textbooks",
                column: "StatusId",
                principalTable: "Statuas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
