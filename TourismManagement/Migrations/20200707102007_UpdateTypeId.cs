using Microsoft.EntityFrameworkCore.Migrations;

namespace TourismManagement.Migrations
{
    public partial class UpdateTypeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AlterColumn<string>(
                name: "TypeName",
                table: "Types",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Tours",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tours_TypeId",
                table: "Tours",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tours_Types_TypeId",
                table: "Tours",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tours_Types_TypeId",
                table: "Tours");

            migrationBuilder.DropIndex(
                name: "IX_Tours_TypeId",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Tours");

            migrationBuilder.AlterColumn<string>(
                name: "TypeName",
                table: "Types",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "TourTypes",
                columns: table => new
                {
                    TourId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false)
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
    }
}
