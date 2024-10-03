using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Manajemen_Peminjaman_Mobil.Migrations
{
    /// <inheritdoc />
    public partial class seeding_some_entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Regions_Offices_OfficeId",
                table: "Regions");

            migrationBuilder.DropIndex(
                name: "IX_Regions_OfficeId",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "OfficeId",
                table: "Regions");

            migrationBuilder.InsertData(
                table: "Departements",
                columns: new[] { "Id", "Departement_Name" },
                values: new object[,]
                {
                    { 1, "Hr" },
                    { 2, "Marketing" },
                    { 3, "Finance" },
                    { 4, "Production" },
                    { 5, "IT" }
                });

            migrationBuilder.InsertData(
                table: "EmployeePositions",
                columns: new[] { "Id", "Jabatan" },
                values: new object[,]
                {
                    { 1, "Kepala Bagian Pool" },
                    { 2, "Manager" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Region_Name" },
                values: new object[,]
                {
                    { 1, "Region A" },
                    { 2, "Region B" },
                    { 3, "Region C" },
                    { 4, "Region D" },
                    { 5, "Region E" },
                    { 6, "Region F" }
                });

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

            migrationBuilder.InsertData(
                table: "Minings",
                columns: new[] { "Id", "Mining_Name", "RegionId" },
                values: new object[,]
                {
                    { 1, "Mining A", 2 },
                    { 2, "Mining B", 3 },
                    { 3, "Mining C", 4 }
                });

            migrationBuilder.InsertData(
                table: "Offices",
                columns: new[] { "Id", "Office_Name", "RegionId", "Unit" },
                values: new object[,]
                {
                    { 1, "Office 1", 1, 1 },
                    { 2, "Office 2", 1, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departements",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departements",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departements",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departements",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Departements",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EmployeePositions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EmployeePositions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Minings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Minings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Minings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AddColumn<int>(
                name: "OfficeId",
                table: "Regions",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "Password",
                value: "$2a$11$Z0TjmzZoJS2HvPiAxZ.LyeSmUsDWObt81hoh15Hwlx42Q2pGfRxa6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "Password",
                value: "$2a$11$/j1nB/HKlIJKM8SWE/MJsO82oKkLdw8/yBqOJArM8RCEmTdx76dKe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                column: "Password",
                value: "$2a$11$0F2MPQOY5KvUlHF7tGjQMOLFnSe2rlvt/msm96uZAwVA11X1GlRd.");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_OfficeId",
                table: "Regions",
                column: "OfficeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Regions_Offices_OfficeId",
                table: "Regions",
                column: "OfficeId",
                principalTable: "Offices",
                principalColumn: "Id");
        }
    }
}
