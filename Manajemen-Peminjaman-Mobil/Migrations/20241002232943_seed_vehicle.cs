using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Manajemen_Peminjaman_Mobil.Migrations
{
    /// <inheritdoc />
    public partial class seed_vehicle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "Password",
                value: "$2a$11$Qo.sygiQMxsK9rt14N1nLeJ22llnM3Ow5ddrhFxGDvGn8bHW4yCzW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "Password",
                value: "$2a$11$l0LZervKgFozqopFNQpb5uxsE7vPqNMocEp.NTVpMGByFkewF062O");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                column: "Password",
                value: "$2a$11$JbGsvTI2Q8QySBsRzxjgguQGo7O555wM7PFcoB2w5uOXxNLZP.Rqe");

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Name", "Plat_Nomor", "Status_Kepemilikan", "Tahun_Kendaraan", "Type" },
                values: new object[,]
                {
                    { 1, "Toyota Avanza", "L 1234 AB", 0, "2020", 0 },
                    { 2, "Isuzu Elf", "B 9876 XY", 1, "2019", 0 },
                    { 3, "Mitsubishi L300", "KT 9124 XY", 0, "2015", 1 },
                    { 4, "Mitsubishi Canter", "KT 1204 XY", 0, "2010", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 4);

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
    }
}
