using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSync.Migrations
{
    /// <inheritdoc />
    public partial class Country : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employers_Addresses_AddressId",
                table: "Employers");

            migrationBuilder.DropIndex(
                name: "IX_Employers_AddressId",
                table: "Employers");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Employers");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Employers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Employers");

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "Employers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Employers_AddressId",
                table: "Employers",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employers_Addresses_AddressId",
                table: "Employers",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
