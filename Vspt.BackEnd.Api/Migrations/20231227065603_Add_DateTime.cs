using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vspt.BackEnd.Api.Migrations
{
    /// <inheritdoc />
    public partial class Add_DateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePlan",
                schema: "VSPT",
                table: "DailyReportingPlanDetails",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "DatePlan",
                schema: "VSPT",
                table: "DailyReportingPlanDetails",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");
        }
    }
}
