using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class onion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e1e4469-67cd-441a-b01c-5e87a56c7865");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5881ba9b-8b85-47f0-ab58-b695306fdac8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8773d8d1-faf9-4402-8ed0-93dc0f5949cd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6b0a9ece-c298-44ff-bf4f-31f8f5620927", "1", "Admin", "Admin" },
                    { "6cb49e7f-8f92-4cf3-a08f-74066a4556be", "3", "HR", "Hr" },
                    { "eb8fafb2-7c25-4f93-a05f-7ff57b5ec107", "2", "User", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b0a9ece-c298-44ff-bf4f-31f8f5620927");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6cb49e7f-8f92-4cf3-a08f-74066a4556be");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb8fafb2-7c25-4f93-a05f-7ff57b5ec107");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2e1e4469-67cd-441a-b01c-5e87a56c7865", "3", "HR", "Hr" },
                    { "5881ba9b-8b85-47f0-ab58-b695306fdac8", "1", "Admin", "Admin" },
                    { "8773d8d1-faf9-4402-8ed0-93dc0f5949cd", "2", "User", "User" }
                });
        }
    }
}
