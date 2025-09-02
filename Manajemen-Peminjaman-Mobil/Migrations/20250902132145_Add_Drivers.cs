using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Manajemen_Peminjaman_Mobil.Migrations
{
    /// <inheritdoc />
    public partial class Add_Drivers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleBookings_Employees_DriverId",
                table: "VehicleBookings");

            migrationBuilder.DropIndex(
                name: "IX_VehicleBookings_DriverId",
                table: "VehicleBookings");

            migrationBuilder.DeleteData(
                table: "VehicleBookings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "VehicleBookings");

            migrationBuilder.AddColumn<string>(
                name: "DriverName",
                table: "VehicleBookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "DepartementId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EmployeePositionId", "Name" },
                values: new object[] { 1, "Josh S" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DepartementId", "EmployeePositionId", "Name", "OfficeId", "Phone_Number", "Tanggal_Lahir" },
                values: new object[] { 4, 2, 2, "John Smith", 1, "08198765422", new DateTime(1980, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "VehicleBookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DriverName", "Tanggal" },
                values: new object[] { "Budi", new DateTime(2025, 9, 1, 20, 21, 44, 598, DateTimeKind.Local).AddTicks(8216) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "DriverName",
                table: "VehicleBookings");

            migrationBuilder.AddColumn<int>(
                name: "DriverId",
                table: "VehicleBookings",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "DepartementId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EmployeePositionId", "Name" },
                values: new object[] { 2, "John Smith" });

            migrationBuilder.UpdateData(
                table: "VehicleBookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DriverId", "Tanggal" },
                values: new object[] { null, new DateTime(2025, 9, 1, 19, 52, 58, 254, DateTimeKind.Local).AddTicks(3529) });

            migrationBuilder.InsertData(
                table: "VehicleBookings",
                columns: new[] { "Id", "DriverId", "Durasi", "EmployeeId", "EndMiningId", "Keperluan", "StartMiningId", "Status", "Tanggal", "VehicleId" },
                values: new object[] { 2, null, 5, 1, 3, "Equipment transfer", 2, "Menunggu", new DateTime(2025, 8, 31, 19, 52, 58, 254, DateTimeKind.Local).AddTicks(3549), 2 });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleBookings_DriverId",
                table: "VehicleBookings",
                column: "DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleBookings_Employees_DriverId",
                table: "VehicleBookings",
                column: "DriverId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
