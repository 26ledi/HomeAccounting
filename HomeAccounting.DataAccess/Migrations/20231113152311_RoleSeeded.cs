using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeAccounting.DataAccess.Migrations
{
    public partial class RoleSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "489bd43d-c2d3-4c0b-89d1-5fd38a3ff984", "1", "Admin", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "489bd43d-c2d3-4c0b-89d1-5fd38a3ff984");
        }
    }
}
