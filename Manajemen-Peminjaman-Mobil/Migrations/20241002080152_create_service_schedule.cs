using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Manajemen_Peminjaman_Mobil.Migrations
{
    /// <inheritdoc />
    public partial class create_service_schedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Biaya = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Keterangan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tanggal_Service = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceSchedules_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceSchedules_VehicleId",
                table: "ServiceSchedules",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceSchedules");
        }
    }
}
