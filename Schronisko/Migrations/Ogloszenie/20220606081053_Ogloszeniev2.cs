using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Schronisko.Migrations.Ogloszenie
{
    public partial class Ogloszeniev2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gatunek",
                table: "Ogloszenie",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Zdjecie",
                table: "Ogloszenie",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gatunek",
                table: "Ogloszenie");

            migrationBuilder.DropColumn(
                name: "Zdjecie",
                table: "Ogloszenie");
        }
    }
}
