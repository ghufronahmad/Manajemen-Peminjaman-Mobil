using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Manajemen_Peminjaman_Mobil.Migrations
{
    /// <inheritdoc />
    public partial class create_fuel_consumption : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FuelConsumptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Odometer = table.Column<int>(type: "int", nullable: false),
                    Biaya = table.Column<int>(type: "int", nullable: false),
                    Keterangan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelConsumptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FuelConsumptions_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FuelConsumptions_VehicleId",
                table: "FuelConsumptions",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FuelConsumptions");
        }
    }
}
