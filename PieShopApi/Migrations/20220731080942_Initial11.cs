using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PieShopApi.Migrations
{
    public partial class Initial11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllPies",
                table: "Pies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AllPies",
                table: "Pies",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
