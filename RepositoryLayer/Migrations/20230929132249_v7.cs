using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class v7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c39c51b-24d5-4ed0-aa2b-c7cbeffc65d2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5079388c-6871-46ea-b4b0-da94955364f9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a141f0a3-e94e-4298-8633-7dcf556074fb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "03bbf16b-2ccb-4cbb-a0e2-d0593450a5d7", "2", "User", "User" },
                    { "1364cef1-dcf9-4e62-9ecf-9ccb5e327ae1", "1", "Admin", "Admin" },
                    { "b59787d9-436e-4b0d-89f2-27a988901762", "3", "HR", "Hr" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03bbf16b-2ccb-4cbb-a0e2-d0593450a5d7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1364cef1-dcf9-4e62-9ecf-9ccb5e327ae1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b59787d9-436e-4b0d-89f2-27a988901762");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2c39c51b-24d5-4ed0-aa2b-c7cbeffc65d2", "2", "User", "User" },
                    { "5079388c-6871-46ea-b4b0-da94955364f9", "1", "Admin", "Admin" },
                    { "a141f0a3-e94e-4298-8633-7dcf556074fb", "3", "HR", "Hr" }
                });
        }
    }
}
