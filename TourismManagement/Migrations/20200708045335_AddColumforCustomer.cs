using Microsoft.EntityFrameworkCore.Migrations;

namespace TourismManagement.Migrations
{
    public partial class AddColumforCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tours",
                table: "Customers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tours",
                table: "Customers");
        }
    }
}
