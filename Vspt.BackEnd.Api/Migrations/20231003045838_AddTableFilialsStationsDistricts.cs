using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vspt.BackEnd.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddTableFilialsStationsDistricts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityClaims",
                schema: "VSPT",
                table: "IdentityClaims");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityClaims",
                schema: "VSPT",
                table: "IdentityClaims",
                columns: new[] { "Id", "ClaimName", "ClaimValue" });

            migrationBuilder.CreateTable(
                name: "FilialsStationsDistricts",
                schema: "VSPT",
                columns: table => new
                {
                    BuId = table.Column<string>(type: "character varying(4)", nullable: false),
                    DistrictId = table.Column<string>(type: "character varying(12)", nullable: false),
                    StationECPId = table.Column<string>(type: "text", nullable: false),
                    StationRZDId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_FilialsStationsDistricts_SprDistricts_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "VSPT",
                        principalTable: "SprDistricts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilialsStationsDistricts_SprFilials_BuId",
                        column: x => x.BuId,
                        principalSchema: "VSPT",
                        principalTable: "SprFilials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilialsStationsDistricts_BuId",
                schema: "VSPT",
                table: "FilialsStationsDistricts",
                column: "BuId");

            migrationBuilder.CreateIndex(
                name: "IX_FilialsStationsDistricts_DistrictId",
                schema: "VSPT",
                table: "FilialsStationsDistricts",
                column: "DistrictId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilialsStationsDistricts",
                schema: "VSPT");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityClaims",
                schema: "VSPT",
                table: "IdentityClaims");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityClaims",
                schema: "VSPT",
                table: "IdentityClaims",
                column: "Id");
        }
    }
}
