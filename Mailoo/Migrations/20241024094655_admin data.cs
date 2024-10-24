using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mailoo.Migrations
{
    /// <inheritdoc />
    public partial class admindata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "ID", "Address", "Discriminator", "Email", "FName", "Gender", "LName", "Password", "PhoneNumber", "RegistrationDate", "UserType", "Username" },
                values: new object[] { 5, "Al-Rawda Street, Off the Nile Courniche, Beni Suef", "User", "MailoEg@gmail.com", "Mailo", 1, "Eg", "Mailoo48", "011111111111", new DateTime(2024, 10, 24, 12, 46, 54, 954, DateTimeKind.Local).AddTicks(5639), 1, "MailoEg" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "ID",
                keyValue: 5);
        }
    }
}
