using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSync.Migrations
{
    /// <inheritdoc />
    public partial class nullableProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Addresses_AddressId",
                table: "Jobs");

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressId",
                table: "Jobs",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Addresses_AddressId",
                table: "Jobs",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Addresses_AddressId",
                table: "Jobs");

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressId",
                table: "Jobs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Addresses_AddressId",
                table: "Jobs",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
