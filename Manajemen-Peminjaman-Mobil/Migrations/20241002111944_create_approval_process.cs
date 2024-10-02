using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Manajemen_Peminjaman_Mobil.Migrations
{
    /// <inheritdoc />
    public partial class create_approval_process : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "approvalProcesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Approved_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rejected_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VehicleBookingId = table.Column<int>(type: "int", nullable: false),
                    ApprovalLevelId = table.Column<int>(type: "int", nullable: false),
                    ApproverId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_approvalProcesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_approvalProcesses_ApproversLevels_ApprovalLevelId",
                        column: x => x.ApprovalLevelId,
                        principalTable: "ApproversLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_approvalProcesses_Approvers_ApproverId",
                        column: x => x.ApproverId,
                        principalTable: "Approvers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_approvalProcesses_VehicleBookings_VehicleBookingId",
                        column: x => x.VehicleBookingId,
                        principalTable: "VehicleBookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_approvalProcesses_ApprovalLevelId",
                table: "approvalProcesses",
                column: "ApprovalLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_approvalProcesses_ApproverId",
                table: "approvalProcesses",
                column: "ApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_approvalProcesses_VehicleBookingId",
                table: "approvalProcesses",
                column: "VehicleBookingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "approvalProcesses");
        }
    }
}
