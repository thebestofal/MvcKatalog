using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcKatalog.Data.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Browary",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(nullable: false),
                    KrajPochodzenia = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Browary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Piwa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(nullable: false),
                    Typ = table.Column<string>(nullable: true),
                    ZawartoscAlk = table.Column<double>(nullable: false),
                    Ibu = table.Column<int>(nullable: false),
                    Ekstrakt = table.Column<double>(nullable: false),
                    BrowarId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Piwa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Piwa_Browary_BrowarId",
                        column: x => x.BrowarId,
                        principalTable: "Browary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Piwa_BrowarId",
                table: "Piwa",
                column: "BrowarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Piwa");

            migrationBuilder.DropTable(
                name: "Browary");
        }
    }
}
