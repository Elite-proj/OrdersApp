using Microsoft.EntityFrameworkCore.Migrations;

namespace Assessment.Migrations
{
    public partial class OrderTypeLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrdersID",
                table: "orderLines",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_orderLines_OrdersID",
                table: "orderLines",
                column: "OrdersID");

            migrationBuilder.AddForeignKey(
                name: "FK_orderLines_orders_OrdersID",
                table: "orderLines",
                column: "OrdersID",
                principalTable: "orders",
                principalColumn: "OrdersID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderLines_orders_OrdersID",
                table: "orderLines");

            migrationBuilder.DropIndex(
                name: "IX_orderLines_OrdersID",
                table: "orderLines");

            migrationBuilder.DropColumn(
                name: "OrdersID",
                table: "orderLines");
        }
    }
}
