using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDate",
                table: "FeedBacks",
                type: "datetime2",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "AddedDate",
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
        }
    }
}
