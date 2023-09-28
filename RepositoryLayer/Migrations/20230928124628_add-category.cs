using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class addcategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3261cbc3-761a-4715-85d1-6dd7ea961032");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4afee511-6956-40f6-b389-853079483c0f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3038550-b3d1-4bdf-ba91-fdceee05887f");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "148dd057-ac99-475d-98c5-f4ce3d19c09d", "3", "HR", "Hr" },
                    { "1c762281-f1e0-4837-a8cb-181817d5aff5", "1", "Admin", "Admin" },
                    { "d9bef1df-f1cd-4aba-9b89-59f836c42487", "2", "User", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "148dd057-ac99-475d-98c5-f4ce3d19c09d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c762281-f1e0-4837-a8cb-181817d5aff5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9bef1df-f1cd-4aba-9b89-59f836c42487");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Recipes");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3261cbc3-761a-4715-85d1-6dd7ea961032", "1", "Admin", "Admin" },
                    { "4afee511-6956-40f6-b389-853079483c0f", "2", "User", "User" },
                    { "f3038550-b3d1-4bdf-ba91-fdceee05887f", "3", "HR", "Hr" }
                });
        }
    }
}
