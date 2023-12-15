using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeAccounting.DataAccess.Migrations
{
    public partial class specialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[,]
                {
                    { "6aa1dddd-f4e9-47da-a02f-9a5a9cffbcdb", "3f97d727-fb5e-47ea-8c66-fb4762631a91", "Admin", "ADMIN" },
                    { "ce39252a-b945-45f6-a5f8-67bcb9b59280", "0987998e-7bef-4a98-9399-3dcf63be1a75", "Client", "CLIENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1621e29e-f36a-4ca2-b130-c1cc26c00e1b", 0, "b639988c-9e65-4bcd-89f1-59a20f38f2ce", "wisdomledi@gmail.com", true, true, null, "WISDOMLEDI@GMAIL.COM", "WISDOM", "AQAAAAEAACcQAAAAEJfRkjKjsjBO5MBHaJPMx3I0UZwFMxCxXCcChIoG39V5yu0GsSxP/P25O4Mxxmovpw==", "+375257716193", true, "17cd487a-1050-4ab6-8ed4-c3e969a9c0b7", false, "Wisdom" },
                    { "9a7a896e-c81d-470f-a6b7-019f2c439919", 0, "d49bd32a-2f9b-4059-9f16-d4c488263d34", "joyceledi26@gmail.com", true, true, null, "JOYCLELEDI26@GMAIL.COM", "LEDI", "AQAAAAEAACcQAAAAEMVUf+80tVuyfiRukF4tvlcWMoy2UkDaO0OFYY+sErqducyII/qGY6Na4I6aWjo6XA==", "+375257716193", true, "d7029d8d-a1ed-464b-bbcd-34ae355dcc6e", false, "Ledi" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ce39252a-b945-45f6-a5f8-67bcb9b59280", "1621e29e-f36a-4ca2-b130-c1cc26c00e1b" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6aa1dddd-f4e9-47da-a02f-9a5a9cffbcdb", "9a7a896e-c81d-470f-a6b7-019f2c439919" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ce39252a-b945-45f6-a5f8-67bcb9b59280", "1621e29e-f36a-4ca2-b130-c1cc26c00e1b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6aa1dddd-f4e9-47da-a02f-9a5a9cffbcdb", "9a7a896e-c81d-470f-a6b7-019f2c439919" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6aa1dddd-f4e9-47da-a02f-9a5a9cffbcdb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce39252a-b945-45f6-a5f8-67bcb9b59280");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1621e29e-f36a-4ca2-b130-c1cc26c00e1b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a7a896e-c81d-470f-a6b7-019f2c439919");

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
    }
}
