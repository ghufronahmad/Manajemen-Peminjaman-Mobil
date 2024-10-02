using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Manajemen_Peminjaman_Mobil.Migrations
{
    /// <inheritdoc />
    public partial class create_vehicle_booking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleBookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Keperluan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Durasi = table.Column<int>(type: "int", nullable: false),
                    Tanggal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartMiningId = table.Column<int>(type: "int", nullable: false),
                    EndMiningId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleBookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleBookings_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VehicleBookings_Minings_EndMiningId",
                        column: x => x.EndMiningId,
                        principalTable: "Minings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VehicleBookings_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleBookings_EmployeeId",
                table: "VehicleBookings",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleBookings_EndMiningId",
                table: "VehicleBookings",
                column: "EndMiningId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleBookings_VehicleId",
                table: "VehicleBookings",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleBookings");
        }
    }
}
