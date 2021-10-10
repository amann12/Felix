using Microsoft.EntityFrameworkCore.Migrations;

namespace Intern.Migrations
{
    public partial class changesInOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrderAssignId",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderAssignId",
                table: "Orders");
        }
    }
}
