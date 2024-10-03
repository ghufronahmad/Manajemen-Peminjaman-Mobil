using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Manajemen_Peminjaman_Mobil.Migrations
{
    /// <inheritdoc />
    public partial class ad_start_end_mining : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_VehicleBookings_StartMiningId",
                table: "VehicleBookings",
                column: "StartMiningId");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleBookings_Minings_StartMiningId",
                table: "VehicleBookings",
                column: "StartMiningId",
                principalTable: "Minings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleBookings_Minings_StartMiningId",
                table: "VehicleBookings");

            migrationBuilder.DropIndex(
                name: "IX_VehicleBookings_StartMiningId",
                table: "VehicleBookings");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "Password",
                value: "$2a$11$U88ESVTWq0cGwizOJ4bCIu8C77S1W2O134t1xtJgetieNaCrBJ5EK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "Password",
                value: "$2a$11$CN90jNe2NowYVK5.Zof8oujy2qxlC.PNTGJoG2JLeOnUS8NIkMQBG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                column: "Password",
                value: "$2a$11$Kt5U8.LS3ZWnAyagN9DZ5uuEgml.u0Abxq/45Ky385N4T39.SWrN6");
        }
    }
}
