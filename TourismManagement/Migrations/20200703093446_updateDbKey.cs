using Microsoft.EntityFrameworkCore.Migrations;

namespace TourismManagement.Migrations
{
    public partial class updateDbKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tours",
                keyColumn: "TourId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tours",
                keyColumn: "TourId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tours",
                keyColumn: "TourId",
                keyValue: 3);

            migrationBuilder.CreateTable(
                name: "TourTypes",
                columns: table => new
                {
                    TourId = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourTypes", x => new { x.TourId, x.TypeId });
                    table.ForeignKey(
                        name: "FK_TourTypes_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "TourId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TourTypes_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TourTypes_TypeId",
                table: "TourTypes",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TourTypes");

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
    }
}
