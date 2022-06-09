using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Schronisko.Migrations
{
    public partial class nowa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsWolontariusz",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsWolontariusz",
                table: "AspNetUsers");
        }
    }
}
