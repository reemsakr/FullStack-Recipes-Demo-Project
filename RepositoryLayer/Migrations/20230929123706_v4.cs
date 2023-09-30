using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "563a5d0b-6892-43ca-b873-8f50c3fe19b1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60ee940e-4125-41d1-a166-adb02b158e5a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3527ca9-a710-421c-9cef-acc972f3cdfa");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FeedBacks");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "04396a1d-2102-4319-9e99-37456c75c9f0", "3", "HR", "Hr" },
                    { "8f657ceb-3408-4926-86e1-5c2cc1d7ec14", "1", "Admin", "Admin" },
                    { "c8322682-36ed-44a8-b955-a0e40a4dbf43", "2", "User", "User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeedBacks_RecipeId",
                table: "FeedBacks",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_FeedBacks_Recipes_RecipeId",
                table: "FeedBacks",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeedBacks_Recipes_RecipeId",
                table: "FeedBacks");

            migrationBuilder.DropIndex(
                name: "IX_FeedBacks_RecipeId",
                table: "FeedBacks");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04396a1d-2102-4319-9e99-37456c75c9f0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f657ceb-3408-4926-86e1-5c2cc1d7ec14");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8322682-36ed-44a8-b955-a0e40a4dbf43");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "FeedBacks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "563a5d0b-6892-43ca-b873-8f50c3fe19b1", "3", "HR", "Hr" },
                    { "60ee940e-4125-41d1-a166-adb02b158e5a", "2", "User", "User" },
                    { "b3527ca9-a710-421c-9cef-acc972f3cdfa", "1", "Admin", "Admin" }
                });
        }
    }
}
