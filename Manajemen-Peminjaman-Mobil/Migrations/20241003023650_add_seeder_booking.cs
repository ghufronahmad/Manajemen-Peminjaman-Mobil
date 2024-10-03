using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Manajemen_Peminjaman_Mobil.Migrations
{
    /// <inheritdoc />
    public partial class add_seeder_booking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "Password",
                value: "$2a$11$bNUtcZu0A8DViKFbS82ZN.uWPNN5iC2hV4vi8VED1jXINAA1PkUGu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "Password",
                value: "$2a$11$mGlsdUWAO48JOqnI6f9ECe96PHyk/E6YTjHDooXmNcRkq9QxGybjO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                column: "Password",
                value: "$2a$11$tN2.aRiPbQpZgP/3.Dev6uLlr0cu59RVk/8dLakSMf.TSFgzfOkau");

            migrationBuilder.InsertData(
                table: "VehicleBookings",
                columns: new[] { "Id", "Durasi", "EmployeeId", "EndMiningId", "Keperluan", "StartMiningId", "Tanggal", "VehicleId" },
                values: new object[,]
                {
                    { 1, 3, 1, 2, "Site inspection", 1, new DateTime(2024, 10, 2, 9, 36, 49, 650, DateTimeKind.Local).AddTicks(4078), 1 },
                    { 2, 5, 1, 3, "Equipment transfer", 2, new DateTime(2024, 10, 1, 9, 36, 49, 650, DateTimeKind.Local).AddTicks(4113), 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VehicleBookings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VehicleBookings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "Password",
                value: "$2a$11$ii5wapLRuITRjSlgbqikLOgfNFKzbQuWs88yFvBgp8JfGVJDT2bb6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "Password",
                value: "$2a$11$HkdEcpxJN/K.LIqA6jYZc.bdGVFay2sRRIh5zmY2O9F8elJNo1Af2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                column: "Password",
                value: "$2a$11$q1/HM68En9fVt5/MLSfxg.FeGinYYH79iY1ZmxVsrg51kvMsXQDci");
        }
    }
}
