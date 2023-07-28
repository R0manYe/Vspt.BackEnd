using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vspt.BackEnd.Api.Migrations
{
    /// <inheritdoc />
    public partial class Clims : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IdentityClaims",
                schema: "VSPT",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUsersClaims",
                schema: "VSPT",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimValue = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUsersClaims", x => new { x.ClaimId, x.UserId });
                    table.ForeignKey(
                        name: "FK_IdentityUsersClaims_IdentityClaims_ClaimId",
                        column: x => x.ClaimId,
                        principalSchema: "VSPT",
                        principalTable: "IdentityClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdentityUsersClaims_IdentityUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "VSPT",
                        principalTable: "IdentityUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUsersClaims_UserId",
                schema: "VSPT",
                table: "IdentityUsersClaims",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityUsersClaims",
                schema: "VSPT");

            migrationBuilder.DropTable(
                name: "IdentityClaims",
                schema: "VSPT");
        }
    }
}
