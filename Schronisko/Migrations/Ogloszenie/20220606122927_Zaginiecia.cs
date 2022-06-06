using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Schronisko.Migrations.Ogloszenie
{
    public partial class Zaginiecia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Zaginiecia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Miejsce = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zdjecie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zaakceptowane = table.Column<bool>(type: "bit", nullable: false),
                    Aktualne = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zaginiecia", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zaginiecia");
        }
    }
}
