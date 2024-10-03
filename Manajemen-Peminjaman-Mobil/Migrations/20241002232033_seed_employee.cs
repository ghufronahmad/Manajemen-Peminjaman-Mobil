using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Manajemen_Peminjaman_Mobil.Migrations
{
    /// <inheritdoc />
    public partial class seed_employee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "EmployeePositionId", "Name", "OfficeId", "Phone_Number", "Tanggal_Lahir" },
                values: new object[,]
                {
                    { 1, 1, "John Doe", 1, "08123456789", new DateTime(1985, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, "Jane Smith", 1, "08198765432", new DateTime(1990, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2, "John Smith", 1, "08198765422", new DateTime(1980, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "Password",
                value: "$2a$11$jm/ssG4rCbybAhR9XypJUeIiYoYYFAP5cuejAwGZziNbDLi8wbhXa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "Password",
                value: "$2a$11$cJ6eTejoy2feRF/AwTd9R.xJMC0S9PI.okNZnY97iFqxdzO7yoOm6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                column: "Password",
                value: "$2a$11$eefl9QJD/K11zDewLZHveuPm/IZthB9Qk7AXfHglqLfocJKCqbp9K");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "Password",
                value: "$2a$11$XskyKq7rYE0YP.5gPGmmMuenDEh1/8EGrTYJ8iM.SimZCtVmlrh4O");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "Password",
                value: "$2a$11$8jH10p4/Iyj5sbqBVeUSCeR4GBPpMhpmr9ZUTuT.k278lGjx01fra");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                column: "Password",
                value: "$2a$11$sB8DCyh2OhcFu3Jv9tisg.ZBmW.vZb3XWZXMinFtvoaZILIF3bvBO");
        }
    }
}
