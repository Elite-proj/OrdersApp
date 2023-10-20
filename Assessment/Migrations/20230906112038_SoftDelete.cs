using Microsoft.EntityFrameworkCore.Migrations;

namespace Assessment.Migrations
{
    public partial class SoftDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeleteStatus",
                table: "orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeleteStatus",
                table: "orderLines",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleteStatus",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "DeleteStatus",
                table: "orderLines");
        }
    }
}
