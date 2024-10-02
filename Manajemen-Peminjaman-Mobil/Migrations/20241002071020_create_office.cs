using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Manajemen_Peminjaman_Mobil.Migrations
{
    /// <inheritdoc />
    public partial class create_office : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OfficeId",
                table: "Regions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Office_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offices_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Regions_OfficeId",
                table: "Regions",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Offices_RegionId",
                table: "Offices",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Regions_Offices_OfficeId",
                table: "Regions",
                column: "OfficeId",
                principalTable: "Offices",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Regions_Offices_OfficeId",
                table: "Regions");

            migrationBuilder.DropTable(
                name: "Offices");

            migrationBuilder.DropIndex(
                name: "IX_Regions_OfficeId",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "OfficeId",
                table: "Regions");
        }
    }
}
