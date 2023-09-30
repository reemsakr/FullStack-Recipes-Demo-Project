using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class v6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60d73cbd-fa82-4a50-8a01-0ccdcabebddd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b37bbd70-2120-4871-ba5b-b3660a65b895");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e44bded0-3ba6-40e7-841a-2c06f0a97374");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "60d73cbd-fa82-4a50-8a01-0ccdcabebddd", "1", "Admin", "Admin" },
                    { "b37bbd70-2120-4871-ba5b-b3660a65b895", "2", "User", "User" },
                    { "e44bded0-3ba6-40e7-841a-2c06f0a97374", "3", "HR", "Hr" }
                });
        }
    }
}
