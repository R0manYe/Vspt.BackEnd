using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Vspt.BackEnd.Api.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "VSPT");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:pgcrypto", ",,");

            migrationBuilder.CreateTable(
                name: "DailyReportingDvigen",
                schema: "VSPT",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DateDvigenReporting = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    idFilial = table.Column<string>(type: "text", nullable: false),
                    idDistrict = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyReportingDvigen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DailyReportingPlan",
                schema: "VSPT",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DatePlanReporting = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    idFilial = table.Column<string>(type: "text", nullable: false),
                    idDistrict = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyReportingPlan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityRoles",
                schema: "VSPT",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUsers",
                schema: "VSPT",
                columns: table => new
                {
                    Username = table.Column<long>(type: "bigint", maxLength: 50, nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<string>(type: "text", nullable: false),
                    RefreshToken = table.Column<string>(type: "text", nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUsers", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "InboxState",
                schema: "VSPT",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MessageId = table.Column<Guid>(type: "uuid", nullable: false),
                    ConsumerId = table.Column<Guid>(type: "uuid", nullable: false),
                    LockId = table.Column<Guid>(type: "uuid", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    Received = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ReceiveCount = table.Column<int>(type: "integer", nullable: false),
                    ExpirationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Consumed = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Delivered = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastSequenceNumber = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InboxState", x => x.Id);
                    table.UniqueConstraint("AK_InboxState_MessageId_ConsumerId", x => new { x.MessageId, x.ConsumerId });
                });

            migrationBuilder.CreateTable(
                name: "OutboxMessage",
                schema: "VSPT",
                columns: table => new
                {
                    SequenceNumber = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EnqueueTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    SentTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Headers = table.Column<string>(type: "text", nullable: true),
                    Properties = table.Column<string>(type: "text", nullable: true),
                    InboxMessageId = table.Column<Guid>(type: "uuid", nullable: true),
                    InboxConsumerId = table.Column<Guid>(type: "uuid", nullable: true),
                    OutboxId = table.Column<Guid>(type: "uuid", nullable: true),
                    MessageId = table.Column<Guid>(type: "uuid", nullable: false),
                    ContentType = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Body = table.Column<string>(type: "text", nullable: false),
                    ConversationId = table.Column<Guid>(type: "uuid", nullable: true),
                    CorrelationId = table.Column<Guid>(type: "uuid", nullable: true),
                    InitiatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    RequestId = table.Column<Guid>(type: "uuid", nullable: true),
                    SourceAddress = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    DestinationAddress = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ResponseAddress = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    FaultAddress = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ExpirationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutboxMessage", x => x.SequenceNumber);
                });

            migrationBuilder.CreateTable(
                name: "OutboxState",
                schema: "VSPT",
                columns: table => new
                {
                    OutboxId = table.Column<Guid>(type: "uuid", nullable: false),
                    LockId = table.Column<Guid>(type: "uuid", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Delivered = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastSequenceNumber = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutboxState", x => x.OutboxId);
                });

            migrationBuilder.CreateTable(
                name: "SprFilials",
                schema: "VSPT",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ShortName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SprFilials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SprSvod",
                schema: "VSPT",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    spr = table.Column<byte>(type: "smallint", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SprSvod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeClaims",
                schema: "VSPT",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "smallint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DailyReportingDvigenDetails",
                schema: "VSPT",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DvigenId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrgId = table.Column<string>(type: "text", nullable: false),
                    GruzGroupId = table.Column<string>(type: "text", nullable: false),
                    LoadingPlan = table.Column<int>(type: "integer", nullable: true),
                    LoadingApplication = table.Column<int>(type: "integer", nullable: true),
                    LoadingSecuredTotal = table.Column<int>(type: "integer", nullable: true),
                    LoadingSecuredLastDay = table.Column<int>(type: "integer", nullable: true),
                    LoadingTotalWagons = table.Column<int>(type: "integer", nullable: true),
                    LoadingTotalTonns = table.Column<int>(type: "integer", nullable: true),
                    LoadingPPGT = table.Column<int>(type: "integer", nullable: true),
                    LoadingFirstHalfDay = table.Column<int>(type: "integer", nullable: true),
                    UnloadingPlan = table.Column<int>(type: "integer", nullable: true),
                    UnloadingRemainsLastDay = table.Column<int>(type: "integer", nullable: true),
                    UnloadingAccesptedTotal = table.Column<int>(type: "integer", nullable: true),
                    UnloadingAccesptedFullTerm = table.Column<int>(type: "integer", nullable: true),
                    UnloadingProduceTotal = table.Column<int>(type: "integer", nullable: true),
                    UnloadingProduceFullTerm = table.Column<int>(type: "integer", nullable: true),
                    UnloadingAccesptedTotalWagons = table.Column<int>(type: "integer", nullable: true),
                    UnloadingAccesptedTotalTonns = table.Column<int>(type: "integer", nullable: true),
                    UnloadingAccesptedPPGT = table.Column<int>(type: "integer", nullable: true),
                    UnloadingAccesptedLastDayWagons = table.Column<int>(type: "integer", nullable: true),
                    UnloadingRemainsTotal = table.Column<int>(type: "integer", nullable: true),
                    UnloadingRemainsFullTerm = table.Column<int>(type: "integer", nullable: true),
                    UnloadingRemainsGuiltPPGT = table.Column<int>(type: "integer", nullable: true),
                    UnloadingRemainsGuiltConsignee = table.Column<int>(type: "integer", nullable: true),
                    Notations = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyReportingDvigenDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyReportingDvigenDetails_DailyReportingDvigen_DvigenId",
                        column: x => x.DvigenId,
                        principalSchema: "VSPT",
                        principalTable: "DailyReportingDvigen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DailyReportingPlanDetails",
                schema: "VSPT",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PlanId = table.Column<Guid>(type: "uuid", nullable: false),
                    FilialId = table.Column<string>(type: "text", nullable: false),
                    OrgId = table.Column<string>(type: "text", nullable: false),
                    GruzGroupId = table.Column<string>(type: "text", nullable: false),
                    LoadingPlan = table.Column<int>(type: "integer", nullable: true),
                    LoadingApplication = table.Column<int>(type: "integer", nullable: true),
                    LoadingSecuredTotal = table.Column<int>(type: "integer", nullable: true),
                    LoadingSecuredLastDay = table.Column<int>(type: "integer", nullable: true),
                    LoadingTotalWagons = table.Column<int>(type: "integer", nullable: true),
                    LoadingTotalTonns = table.Column<int>(type: "integer", nullable: true),
                    LoadingPPGT = table.Column<int>(type: "integer", nullable: true),
                    LoadingFirstHalfDay = table.Column<int>(type: "integer", nullable: true),
                    UnloadingPlan = table.Column<int>(type: "integer", nullable: true),
                    UnloadingRemainsLastDay = table.Column<int>(type: "integer", nullable: true),
                    UnloadingAccesptedTotal = table.Column<int>(type: "integer", nullable: true),
                    UnloadingAccesptedFullTerm = table.Column<int>(type: "integer", nullable: true),
                    UnloadingProduceTotal = table.Column<int>(type: "integer", nullable: true),
                    UnloadingProduceFullTerm = table.Column<int>(type: "integer", nullable: true),
                    UnloadingAccesptedTotalWagons = table.Column<int>(type: "integer", nullable: true),
                    UnloadingAccesptedTotalTonns = table.Column<int>(type: "integer", nullable: true),
                    UnloadingAccesptedPPGT = table.Column<int>(type: "integer", nullable: true),
                    UnloadingAccesptedLastDayWagons = table.Column<int>(type: "integer", nullable: true),
                    UnloadingRemainsTotal = table.Column<int>(type: "integer", nullable: true),
                    UnloadingRemainsFullTerm = table.Column<int>(type: "integer", nullable: true),
                    UnloadingRemainsGuiltPPGT = table.Column<int>(type: "integer", nullable: true),
                    UnloadingRemainsGuiltConsignee = table.Column<int>(type: "integer", nullable: true),
                    Notations = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyReportingPlanDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyReportingPlanDetails_DailyReportingPlan_PlanId",
                        column: x => x.PlanId,
                        principalSchema: "VSPT",
                        principalTable: "DailyReportingPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SprDistricts",
                schema: "VSPT",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    District_id_txt = table.Column<string>(type: "text", nullable: false),
                    Bu_id = table.Column<string>(type: "character varying(4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SprDistricts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SprDistricts_SprFilials_Bu_id",
                        column: x => x.Bu_id,
                        principalSchema: "VSPT",
                        principalTable: "SprFilials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityClaims",
                schema: "VSPT",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimName = table.Column<byte>(type: "smallint", nullable: false),
                    ClaimUser = table.Column<long>(type: "bigint", nullable: false),
                    ClaimValue = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityClaims_IdentityUsers_ClaimUser",
                        column: x => x.ClaimUser,
                        principalSchema: "VSPT",
                        principalTable: "IdentityUsers",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdentityClaims_TypeClaims_ClaimName",
                        column: x => x.ClaimName,
                        principalSchema: "VSPT",
                        principalTable: "TypeClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_DailyReportingDvigenDetails_DvigenId",
                schema: "VSPT",
                table: "DailyReportingDvigenDetails",
                column: "DvigenId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportingPlanDetails_PlanId",
                schema: "VSPT",
                table: "DailyReportingPlanDetails",
                column: "PlanId");

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

            migrationBuilder.CreateIndex(
                name: "IX_IdentityClaims_ClaimName",
                schema: "VSPT",
                table: "IdentityClaims",
                column: "ClaimName");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityClaims_ClaimUser",
                schema: "VSPT",
                table: "IdentityClaims",
                column: "ClaimUser");

            migrationBuilder.CreateIndex(
                name: "IX_InboxState_Delivered",
                schema: "VSPT",
                table: "InboxState",
                column: "Delivered");

            migrationBuilder.CreateIndex(
                name: "IX_OutboxMessage_EnqueueTime",
                schema: "VSPT",
                table: "OutboxMessage",
                column: "EnqueueTime");

            migrationBuilder.CreateIndex(
                name: "IX_OutboxMessage_ExpirationTime",
                schema: "VSPT",
                table: "OutboxMessage",
                column: "ExpirationTime");

            migrationBuilder.CreateIndex(
                name: "IX_OutboxMessage_InboxMessageId_InboxConsumerId_SequenceNumber",
                schema: "VSPT",
                table: "OutboxMessage",
                columns: new[] { "InboxMessageId", "InboxConsumerId", "SequenceNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OutboxMessage_OutboxId_SequenceNumber",
                schema: "VSPT",
                table: "OutboxMessage",
                columns: new[] { "OutboxId", "SequenceNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OutboxState_Created",
                schema: "VSPT",
                table: "OutboxState",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_SprDistricts_Bu_id",
                schema: "VSPT",
                table: "SprDistricts",
                column: "Bu_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyReportingDvigenDetails",
                schema: "VSPT");

            migrationBuilder.DropTable(
                name: "DailyReportingPlanDetails",
                schema: "VSPT");

            migrationBuilder.DropTable(
                name: "FilialsStationsDistricts",
                schema: "VSPT");

            migrationBuilder.DropTable(
                name: "IdentityClaims",
                schema: "VSPT");

            migrationBuilder.DropTable(
                name: "IdentityRoles",
                schema: "VSPT");

            migrationBuilder.DropTable(
                name: "InboxState",
                schema: "VSPT");

            migrationBuilder.DropTable(
                name: "OutboxMessage",
                schema: "VSPT");

            migrationBuilder.DropTable(
                name: "OutboxState",
                schema: "VSPT");

            migrationBuilder.DropTable(
                name: "SprSvod",
                schema: "VSPT");

            migrationBuilder.DropTable(
                name: "DailyReportingDvigen",
                schema: "VSPT");

            migrationBuilder.DropTable(
                name: "DailyReportingPlan",
                schema: "VSPT");

            migrationBuilder.DropTable(
                name: "SprDistricts",
                schema: "VSPT");

            migrationBuilder.DropTable(
                name: "IdentityUsers",
                schema: "VSPT");

            migrationBuilder.DropTable(
                name: "TypeClaims",
                schema: "VSPT");

            migrationBuilder.DropTable(
                name: "SprFilials",
                schema: "VSPT");
        }
    }
}
