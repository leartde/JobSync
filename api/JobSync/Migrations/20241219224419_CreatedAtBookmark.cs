using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JobSync.Migrations
{
    /// <inheritdoc />
    public partial class CreatedAtBookmark : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2186c431-bc06-4195-8b9a-16af30848b78"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8904f535-d321-4b6c-a129-fe00cb7a0aa2"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ae02f401-7998-439c-a9da-9c25480c79e6"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Bookmarks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("25db0412-6ae3-4e52-a7d1-1f4294cefbc8"), null, "Admin", "ADMIN" },
                    { new Guid("6df94a59-f9d6-442a-bfed-fb85315127e3"), null, "JobSeeker", "JOBSEEKER" },
                    { new Guid("c58171d9-0431-4390-bb40-c050f929224b"), null, "Employer", "EMPLOYER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("25db0412-6ae3-4e52-a7d1-1f4294cefbc8"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6df94a59-f9d6-442a-bfed-fb85315127e3"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c58171d9-0431-4390-bb40-c050f929224b"));

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Bookmarks");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Jobs",
                newName: "PhotoUrl");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("2186c431-bc06-4195-8b9a-16af30848b78"), null, "Admin", "ADMIN" },
                    { new Guid("8904f535-d321-4b6c-a129-fe00cb7a0aa2"), null, "JobSeeker", "JOBSEEKER" },
                    { new Guid("ae02f401-7998-439c-a9da-9c25480c79e6"), null, "Employer", "EMPLOYER" }
                });
        }
    }
}
