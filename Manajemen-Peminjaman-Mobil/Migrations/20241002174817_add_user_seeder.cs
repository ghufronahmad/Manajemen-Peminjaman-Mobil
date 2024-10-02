using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Manajemen_Peminjaman_Mobil.Migrations
{
    /// <inheritdoc />
    public partial class add_user_seeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "admin@gmail.com", "Admin User", "$2a$11$Z0TjmzZoJS2HvPiAxZ.LyeSmUsDWObt81hoh15Hwlx42Q2pGfRxa6", 0 },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "approver1@gmail.com", "Approver 1", "$2a$11$/j1nB/HKlIJKM8SWE/MJsO82oKkLdw8/yBqOJArM8RCEmTdx76dKe", 1 },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "approver2@gmail.com", "Approver 2", "$2a$11$0F2MPQOY5KvUlHF7tGjQMOLFnSe2rlvt/msm96uZAwVA11X1GlRd.", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));
        }
    }
}
