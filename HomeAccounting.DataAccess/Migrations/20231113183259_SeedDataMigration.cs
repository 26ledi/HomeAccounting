using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeAccounting.DataAccess.Migrations
{
    public partial class SeedDataMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "e51c857a-74aa-46a6-92bc-6d9f4fba0b28", "ab3149de-9ea6-4b86-951c-d1d24af345a7", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "dcab4b2e-8087-4705-a0e9-6af605af5e73", 0, "3d6dff4d-a770-4186-ab95-f7720a6c0477", "joyceledi26@gmail.com", true, true, null, "JOYCLELEDI26@GMAIL.COM", "LEDI", "AQAAAAEAACcQAAAAELO/zSOjiZYq9z0skakDjU0iEATKQrw81OaNcSItmFOFRrp0/dk3ppKV4IYSTBKL0w==", "+375257716193", true, "3aca809c-5e1b-44ed-97e7-55509a5119be", false, "Ledi" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e51c857a-74aa-46a6-92bc-6d9f4fba0b28", "dcab4b2e-8087-4705-a0e9-6af605af5e73" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e51c857a-74aa-46a6-92bc-6d9f4fba0b28", "dcab4b2e-8087-4705-a0e9-6af605af5e73" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e51c857a-74aa-46a6-92bc-6d9f4fba0b28");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dcab4b2e-8087-4705-a0e9-6af605af5e73");

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
    }
}
