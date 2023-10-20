using Microsoft.EntityFrameworkCore.Migrations;

namespace Assessment.Migrations
{
    public partial class IdentityTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "userRoles",
                columns: table => new
                {
                    UserRoleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserRoleDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userRoles", x => x.UserRoleID);
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    AppUsersID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: false),
                    ConfirmEmail = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    ConfirmPassword = table.Column<string>(nullable: false),
                    UserRoleID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.AppUsersID);
                    table.ForeignKey(
                        name: "FK_AppUsers_userRoles_UserRoleID",
                        column: x => x.UserRoleID,
                        principalTable: "userRoles",
                        principalColumn: "UserRoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "userRoles",
                columns: new[] { "UserRoleID", "UserRoleDescription" },
                values: new object[] { 1, "Admin" });

            migrationBuilder.InsertData(
                table: "userRoles",
                columns: new[] { "UserRoleID", "UserRoleDescription" },
                values: new object[] { 2, "Guest" });

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_UserRoleID",
                table: "AppUsers",
                column: "UserRoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "userRoles");
        }
    }
}
