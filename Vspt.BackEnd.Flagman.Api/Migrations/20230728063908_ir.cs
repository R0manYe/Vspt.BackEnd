using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vspt.BackEnd.Flagman.Api.Migrations
{
    /// <inheritdoc />
    public partial class ir : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "VSPTSVOD");

            migrationBuilder.CreateTable(
                name: "GETALLDISLOKACIA",
                schema: "VSPTSVOD",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NOM_VAG = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    RAILWAYS = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    NAIM_ROD_VAG = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    STAN_NAZN = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    NAIM_STAN_NAZN = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    GRUZPOL_OKPO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    NAIM_GRUZPOL_OKPO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    NAIM_GRUZOTPR_OKPO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    NAIM_KOD_GRZ = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    VES_GRZ = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    DATE_OP = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    NAIM_STAN_OP = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    RASST_STAN_NAZN = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DATE_DOSTAV = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    NAIM_KOP_VMD = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    NOM_POEZD = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    INDEX_POEZD = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    NPP_VAG = table.Column<string>(type: "NVARCHAR2(2000)", precision: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GETALLDISLOKACIA", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "InboxState",
                schema: "VSPTSVOD",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    MessageId = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    ConsumerId = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    LockId = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "RAW(8)", rowVersion: true, nullable: true),
                    Received = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ReceiveCount = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ExpirationTime = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    Consumed = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    Delivered = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    LastSequenceNumber = table.Column<long>(type: "NUMBER(19)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InboxState", x => x.Id);
                    table.UniqueConstraint("AK_InboxState_MessageId_ConsumerId", x => new { x.MessageId, x.ConsumerId });
                });

            migrationBuilder.CreateTable(
                name: "OutboxMessage",
                schema: "VSPTSVOD",
                columns: table => new
                {
                    SequenceNumber = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    EnqueueTime = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    SentTime = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Headers = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Properties = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    InboxMessageId = table.Column<Guid>(type: "RAW(16)", nullable: true),
                    InboxConsumerId = table.Column<Guid>(type: "RAW(16)", nullable: true),
                    OutboxId = table.Column<Guid>(type: "RAW(16)", nullable: true),
                    MessageId = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    ContentType = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: false),
                    Body = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ConversationId = table.Column<Guid>(type: "RAW(16)", nullable: true),
                    CorrelationId = table.Column<Guid>(type: "RAW(16)", nullable: true),
                    InitiatorId = table.Column<Guid>(type: "RAW(16)", nullable: true),
                    RequestId = table.Column<Guid>(type: "RAW(16)", nullable: true),
                    SourceAddress = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    DestinationAddress = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    ResponseAddress = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    FaultAddress = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    ExpirationTime = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutboxMessage", x => x.SequenceNumber);
                });

            migrationBuilder.CreateTable(
                name: "OutboxState",
                schema: "VSPTSVOD",
                columns: table => new
                {
                    OutboxId = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    LockId = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "RAW(8)", rowVersion: true, nullable: true),
                    Created = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Delivered = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    LastSequenceNumber = table.Column<long>(type: "NUMBER(19)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutboxState", x => x.OutboxId);
                });

            migrationBuilder.CreateTable(
                name: "SPR_COLLECTION",
                schema: "VSPTSVOD",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ID_SPR = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    NAIM = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    SV = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ID_SP = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SPR_COLLECTION", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SPR_ETRAN_RAILWAYS",
                schema: "VSPTSVOD",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NAME = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SPR_ETRAN_RAILWAYS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VSPT_SUBJECT_PERSONE",
                schema: "VSPTSVOD",
                columns: table => new
                {
                    ID = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    LAST_NAME = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    FIRST_NAME = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    SECOND_NAME = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PROF_ID = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PROF = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DIV_ID = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DIV_NAME = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    BU = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    BU_ID = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VSPT_SUBJECT_PERSONE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DISLOKACIA",
                schema: "VSPTSVOD",
                columns: table => new
                {
                    ID = table.Column<long>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NOM_VAG = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DATE_NACH = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    STAN_NACH = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    STAN_NAZN = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DATE_DOSTAV = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    RASST_STAN_NAZN = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DATE_PRIB = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    GRUZPOL_OKPO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    VES_GRZ = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    DATE_OP = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    DOR_RASCH = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    INDEX_POEZD = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    NOM_POEZD = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NPP_VAG = table.Column<string>(type: "NVARCHAR2(2000)", precision: 3, nullable: false),
                    NAIM_ROD_VAG = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NAIM_STAN_NAZN = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NAIM_GRUZPOL_OKPO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NAIM_KOD_GRZ = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    NAIM_STAN_OP = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NAIM_KOP_VMD = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NAIM_GRUZOTPR_OKPO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Spr_Etran_RailwaysID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DISLOKACIA", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DISLOKACIA_SPR_ETRAN_RAILWAYS_Spr_Etran_RailwaysID",
                        column: x => x.Spr_Etran_RailwaysID,
                        principalSchema: "VSPTSVOD",
                        principalTable: "SPR_ETRAN_RAILWAYS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DISLOKACIA_Spr_Etran_RailwaysID",
                schema: "VSPTSVOD",
                table: "DISLOKACIA",
                column: "Spr_Etran_RailwaysID");

            migrationBuilder.CreateIndex(
                name: "IX_InboxState_Delivered",
                schema: "VSPTSVOD",
                table: "InboxState",
                column: "Delivered");

            migrationBuilder.CreateIndex(
                name: "IX_OutboxMessage_EnqueueTime",
                schema: "VSPTSVOD",
                table: "OutboxMessage",
                column: "EnqueueTime");

            migrationBuilder.CreateIndex(
                name: "IX_OutboxMessage_ExpirationTime",
                schema: "VSPTSVOD",
                table: "OutboxMessage",
                column: "ExpirationTime");

            migrationBuilder.CreateIndex(
                name: "IX_OutboxMessage_InboxMessageId_InboxConsumerId_SequenceNumber",
                schema: "VSPTSVOD",
                table: "OutboxMessage",
                columns: new[] { "InboxMessageId", "InboxConsumerId", "SequenceNumber" },
                unique: true,
                filter: "\"InboxMessageId\" IS NOT NULL AND \"InboxConsumerId\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OutboxMessage_OutboxId_SequenceNumber",
                schema: "VSPTSVOD",
                table: "OutboxMessage",
                columns: new[] { "OutboxId", "SequenceNumber" },
                unique: true,
                filter: "\"OutboxId\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OutboxState_Created",
                schema: "VSPTSVOD",
                table: "OutboxState",
                column: "Created");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DISLOKACIA",
                schema: "VSPTSVOD");

            migrationBuilder.DropTable(
                name: "GETALLDISLOKACIA",
                schema: "VSPTSVOD");

            migrationBuilder.DropTable(
                name: "InboxState",
                schema: "VSPTSVOD");

            migrationBuilder.DropTable(
                name: "OutboxMessage",
                schema: "VSPTSVOD");

            migrationBuilder.DropTable(
                name: "OutboxState",
                schema: "VSPTSVOD");

            migrationBuilder.DropTable(
                name: "SPR_COLLECTION",
                schema: "VSPTSVOD");

            migrationBuilder.DropTable(
                name: "VSPT_SUBJECT_PERSONE",
                schema: "VSPTSVOD");

            migrationBuilder.DropTable(
                name: "SPR_ETRAN_RAILWAYS",
                schema: "VSPTSVOD");
        }
    }
}
