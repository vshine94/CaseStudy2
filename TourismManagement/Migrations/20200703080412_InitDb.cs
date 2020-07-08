using Microsoft.EntityFrameworkCore.Migrations;

namespace TourismManagement.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tours",
                columns: table => new
                {
                    TourId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TourName = table.Column<string>(nullable: true),
                    TourImage = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.TourId);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    TypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.TypeId);
                });

            migrationBuilder.InsertData(
                table: "Tours",
                columns: new[] { "TourId", "Description", "Price", "TourImage", "TourName" },
                values: new object[] { 1, "", 15000000L, "", "Hue-HCM" });

            migrationBuilder.InsertData(
                table: "Tours",
                columns: new[] { "TourId", "Description", "Price", "TourImage", "TourName" },
                values: new object[] { 2, "", 20000000L, "", "Hue-HaNoi" });

            migrationBuilder.InsertData(
                table: "Tours",
                columns: new[] { "TourId", "Description", "Price", "TourImage", "TourName" },
                values: new object[] { 3, "", 30000000L, "", "Singapore" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tours");

            migrationBuilder.DropTable(
                name: "Types");
        }
    }
}
