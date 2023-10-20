using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Assessment.Migrations
{
    public partial class Entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "orderStatuses",
                columns: table => new
                {
                    OrderStatusID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderStatuses", x => x.OrderStatusID);
                });

            migrationBuilder.CreateTable(
                name: "orderTypes",
                columns: table => new
                {
                    OrderTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderTypes", x => x.OrderTypeID);
                });

            migrationBuilder.CreateTable(
                name: "productTypes",
                columns: table => new
                {
                    ProductTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductTypeDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productTypes", x => x.ProductTypeID);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    OrdersID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<int>(nullable: false),
                    CustomerName = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    OrderTypeID = table.Column<int>(nullable: false),
                    OrderStatusID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.OrdersID);
                    table.ForeignKey(
                        name: "FK_orders_orderStatuses_OrderStatusID",
                        column: x => x.OrderStatusID,
                        principalTable: "orderStatuses",
                        principalColumn: "OrderStatusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orders_orderTypes_OrderTypeID",
                        column: x => x.OrderTypeID,
                        principalTable: "orderTypes",
                        principalColumn: "OrderTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orderLines",
                columns: table => new
                {
                    OrderLineID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LineNumber = table.Column<int>(nullable: false),
                    ProductCode = table.Column<string>(nullable: false),
                    ProductCostPrice = table.Column<double>(nullable: false),
                    ProductSalePrice = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    ProductTypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderLines", x => x.OrderLineID);
                    table.ForeignKey(
                        name: "FK_orderLines_productTypes_ProductTypeID",
                        column: x => x.ProductTypeID,
                        principalTable: "productTypes",
                        principalColumn: "ProductTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "orderStatuses",
                columns: new[] { "OrderStatusID", "StatusDescription" },
                values: new object[,]
                {
                    { 1, "New" },
                    { 2, "Processing" },
                    { 3, "Complete" }
                });

            migrationBuilder.InsertData(
                table: "orderTypes",
                columns: new[] { "OrderTypeID", "TypeDescription" },
                values: new object[,]
                {
                    { 1, "Normal" },
                    { 2, "Staff" },
                    { 3, "Mechanical" },
                    { 4, "Perishable" }
                });

            migrationBuilder.InsertData(
                table: "productTypes",
                columns: new[] { "ProductTypeID", "ProductTypeDescription" },
                values: new object[,]
                {
                    { 1, "Apparel" },
                    { 2, "Parts" },
                    { 3, "Equipment" },
                    { 4, "Motor" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_orderLines_ProductTypeID",
                table: "orderLines",
                column: "ProductTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_orders_OrderStatusID",
                table: "orders",
                column: "OrderStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_orders_OrderTypeID",
                table: "orders",
                column: "OrderTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orderLines");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "productTypes");

            migrationBuilder.DropTable(
                name: "orderStatuses");

            migrationBuilder.DropTable(
                name: "orderTypes");
        }
    }
}
