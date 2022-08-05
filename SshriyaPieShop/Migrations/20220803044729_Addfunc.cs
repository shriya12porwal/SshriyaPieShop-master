using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SshriyaPieShop.Migrations
{
    public partial class Addfunc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Bill",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bill",
                table: "Orders");
        }
    }
}
