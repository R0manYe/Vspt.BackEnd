using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vspt.BackEnd.Api.Migrations
{
    /// <inheritdoc />
    public partial class ClimsUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUsersClaims_IdentityUsers_UserId",
                schema: "VSPT",
                table: "IdentityUsersClaims");

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUsersClaims_IdentityClaims_UserId",
                schema: "VSPT",
                table: "IdentityUsersClaims",
                column: "UserId",
                principalSchema: "VSPT",
                principalTable: "IdentityClaims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUsersClaims_IdentityClaims_UserId",
                schema: "VSPT",
                table: "IdentityUsersClaims");

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUsersClaims_IdentityUsers_UserId",
                schema: "VSPT",
                table: "IdentityUsersClaims",
                column: "UserId",
                principalSchema: "VSPT",
                principalTable: "IdentityUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
