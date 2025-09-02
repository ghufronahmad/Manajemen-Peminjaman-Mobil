using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Manajemen_Peminjaman_Mobil.Migrations
{
    /// <inheritdoc />
    public partial class delete_departemen_approver : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Approvers_Departements_DepartementId",
                table: "Approvers");

            migrationBuilder.DropIndex(
                name: "IX_Approvers_DepartementId",
                table: "Approvers");

            migrationBuilder.DropColumn(
                name: "DepartementId",
                table: "Approvers");

            migrationBuilder.UpdateData(
                table: "VehicleBookings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Tanggal",
                value: new DateTime(2025, 9, 1, 19, 52, 58, 254, DateTimeKind.Local).AddTicks(3529));

            migrationBuilder.UpdateData(
                table: "VehicleBookings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Tanggal",
                value: new DateTime(2025, 8, 31, 19, 52, 58, 254, DateTimeKind.Local).AddTicks(3549));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartementId",
                table: "Approvers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "VehicleBookings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Tanggal",
                value: new DateTime(2025, 9, 1, 18, 46, 57, 355, DateTimeKind.Local).AddTicks(5455));

            migrationBuilder.UpdateData(
                table: "VehicleBookings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Tanggal",
                value: new DateTime(2025, 8, 31, 18, 46, 57, 355, DateTimeKind.Local).AddTicks(5497));

            migrationBuilder.CreateIndex(
                name: "IX_Approvers_DepartementId",
                table: "Approvers",
                column: "DepartementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Approvers_Departements_DepartementId",
                table: "Approvers",
                column: "DepartementId",
                principalTable: "Departements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
