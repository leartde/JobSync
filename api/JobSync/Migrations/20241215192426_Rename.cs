using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JobSync.Migrations
{
    /// <inheritdoc />
    public partial class Rename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_JobSeeker_JobSeekerId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Jobs_JobId",
                table: "Applications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Applications",
                table: "Applications");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0e7d3513-bbe0-41b8-bcd9-235884cc4b63"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6bdfc4f1-72d1-4443-8eaa-d93307c66659"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e2b03115-4d35-4479-b51d-ebda036e0ad5"));

            migrationBuilder.RenameTable(
                name: "Applications",
                newName: "JobApplications");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_JobSeekerId",
                table: "JobApplications",
                newName: "IX_JobApplications_JobSeekerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobApplications",
                table: "JobApplications",
                columns: new[] { "JobId", "JobSeekerId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("2186c431-bc06-4195-8b9a-16af30848b78"), null, "Admin", "ADMIN" },
                    { new Guid("8904f535-d321-4b6c-a129-fe00cb7a0aa2"), null, "JobSeeker", "JOBSEEKER" },
                    { new Guid("ae02f401-7998-439c-a9da-9c25480c79e6"), null, "Employer", "EMPLOYER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_JobSeeker_JobSeekerId",
                table: "JobApplications",
                column: "JobSeekerId",
                principalTable: "JobSeeker",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_Jobs_JobId",
                table: "JobApplications",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_JobSeeker_JobSeekerId",
                table: "JobApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_Jobs_JobId",
                table: "JobApplications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobApplications",
                table: "JobApplications");

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

            migrationBuilder.RenameTable(
                name: "JobApplications",
                newName: "Applications");

            migrationBuilder.RenameIndex(
                name: "IX_JobApplications_JobSeekerId",
                table: "Applications",
                newName: "IX_Applications_JobSeekerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Applications",
                table: "Applications",
                columns: new[] { "JobId", "JobSeekerId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0e7d3513-bbe0-41b8-bcd9-235884cc4b63"), null, "Admin", "ADMIN" },
                    { new Guid("6bdfc4f1-72d1-4443-8eaa-d93307c66659"), null, "Employer", "EMPLOYER" },
                    { new Guid("e2b03115-4d35-4479-b51d-ebda036e0ad5"), null, "JobSeeker", "JOBSEEKER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_JobSeeker_JobSeekerId",
                table: "Applications",
                column: "JobSeekerId",
                principalTable: "JobSeeker",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Jobs_JobId",
                table: "Applications",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id");
        }
    }
}
