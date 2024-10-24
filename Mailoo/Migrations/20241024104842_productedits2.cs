using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mailoo.Migrations
{
    /// <inheritdoc />
    public partial class productedits2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ID", "AdditionDate", "Category", "Description", "Discount", "ImageUrl", "Name", "Price", "Quantity", "dbImage" },
                values: new object[] { 5, "24/10/2024 01:48:41 م", 1, "This is a white hoodi", 50m, null, "Mailo basha Hoodi", 500m, 10, null });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "ID",
                keyValue: 5,
                column: "RegistrationDate",
                value: new DateTime(2024, 10, 24, 13, 48, 41, 758, DateTimeKind.Local).AddTicks(1711));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "ID",
                keyValue: 5,
                column: "RegistrationDate",
                value: new DateTime(2024, 10, 24, 13, 43, 7, 852, DateTimeKind.Local).AddTicks(2471));
        }
    }
}
