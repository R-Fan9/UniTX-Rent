using Microsoft.EntityFrameworkCore.Migrations;

namespace RentData.Migrations
{
    public partial class AddNumberOfRentOutstoTextbook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfRentOuts",
                table: "Textbooks",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfRentOuts",
                table: "Textbooks");
        }
    }
}
