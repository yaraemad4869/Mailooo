using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mailoo.Migrations
{
    /// <inheritdoc />
    public partial class productedits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Product",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "ID",
                keyValue: 5,
                column: "RegistrationDate",
                value: new DateTime(2024, 10, 24, 13, 43, 7, 852, DateTimeKind.Local).AddTicks(2471));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Product",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "ID",
                keyValue: 5,
                column: "RegistrationDate",
                value: new DateTime(2024, 10, 24, 12, 46, 54, 954, DateTimeKind.Local).AddTicks(5639));
        }
    }
}
