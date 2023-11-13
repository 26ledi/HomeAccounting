using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeAccounting.DataAccess.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "489bd43d-c2d3-4c0b-89d1-5fd38a3ff984");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4ea54c78-0347-476c-8064-4592fbe45dbc", "f10f34fa-3c70-4ae6-b36c-e8c400f0b952", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "327cbc94-09f0-4b6a-bb2c-cfb70e4b5998", 0, "2fe08199-d4f9-453a-aa63-f15d8979a17b", "joyceledi26@gmail.com", true, true, null, "JOYCLELEDI26@GMAIL.COM", "LEDI", null, "+375257716193", true, "729eed82-845a-4fb1-8898-c839e2a2b7b1", false, "Ledi" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4ea54c78-0347-476c-8064-4592fbe45dbc", "327cbc94-09f0-4b6a-bb2c-cfb70e4b5998" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4ea54c78-0347-476c-8064-4592fbe45dbc", "327cbc94-09f0-4b6a-bb2c-cfb70e4b5998" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ea54c78-0347-476c-8064-4592fbe45dbc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "327cbc94-09f0-4b6a-bb2c-cfb70e4b5998");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "489bd43d-c2d3-4c0b-89d1-5fd38a3ff984", "1", "Admin", "Admin" });
        }
    }
}
