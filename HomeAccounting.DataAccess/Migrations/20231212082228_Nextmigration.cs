using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeAccounting.DataAccess.Migrations
{
    public partial class Nextmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "56b9e7d7-7a70-417f-b5ad-32357741864c", "34aae3e7-562b-464c-acdb-40875544988a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "430fcc0d-4d2b-45b8-b437-de23304da012", 0, "fe59fdc3-192a-48da-8fee-0d175d9fa01c", "joyceledi26@gmail.com", true, true, null, "JOYCLELEDI26@GMAIL.COM", "LEDI", "AQAAAAEAACcQAAAAEJBo8llsTfrUj563FTq/WX+CU1BE7sY0m4ln5xMgYKVSKE3Jw0UIrND+grm9ufaOtg==", "+375257716193", true, "3c2d005a-8e33-4b07-a8e1-dc67cd5f0e54", false, "Ledi" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "56b9e7d7-7a70-417f-b5ad-32357741864c", "430fcc0d-4d2b-45b8-b437-de23304da012" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "56b9e7d7-7a70-417f-b5ad-32357741864c", "430fcc0d-4d2b-45b8-b437-de23304da012" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56b9e7d7-7a70-417f-b5ad-32357741864c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "430fcc0d-4d2b-45b8-b437-de23304da012");

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
    }
}
