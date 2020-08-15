using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessHub.Migrations
{
    public partial class BusinessHubDALBusinessHubDBContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "UserInfo",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.UserId);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "UserInfo",
                columns: new[] { "UserId", "FirstName", "LastName", "Password", "UserName" },
                values: new object[] { new Guid("e929c12b-5a1d-449d-bac1-fd0d23102b01"), "Admin", "User", "Admin@123", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserInfo",
                schema: "dbo");
        }
    }
}
