﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Vspt.BackEnd.Infrastructure.Database.EntityConfigurations;

#nullable disable

namespace Vspt.BackEnd.Api.Migrations
{
    [DbContext(typeof(PgContext))]
    partial class PgContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("VSPT")
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "pgcrypto");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MassTransit.EntityFrameworkCoreIntegration.InboxState", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("Consumed")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("ConsumerId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("Delivered")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("ExpirationTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("LastSequenceNumber")
                        .HasColumnType("bigint");

                    b.Property<Guid>("LockId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("MessageId")
                        .HasColumnType("uuid");

                    b.Property<int>("ReceiveCount")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Received")
                        .HasColumnType("timestamp without time zone");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("bytea");

                    b.HasKey("Id");

                    b.HasAlternateKey("MessageId", "ConsumerId");

                    b.HasIndex("Delivered");

                    b.ToTable("InboxState", "VSPT");
                });

            modelBuilder.Entity("MassTransit.EntityFrameworkCoreIntegration.OutboxMessage", b =>
                {
                    b.Property<long>("SequenceNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("SequenceNumber"));

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<Guid?>("ConversationId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CorrelationId")
                        .HasColumnType("uuid");

                    b.Property<string>("DestinationAddress")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<DateTime?>("EnqueueTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("ExpirationTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("FaultAddress")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("Headers")
                        .HasColumnType("text");

                    b.Property<Guid?>("InboxConsumerId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("InboxMessageId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("InitiatorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("MessageId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("OutboxId")
                        .HasColumnType("uuid");

                    b.Property<string>("Properties")
                        .HasColumnType("text");

                    b.Property<Guid?>("RequestId")
                        .HasColumnType("uuid");

                    b.Property<string>("ResponseAddress")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<DateTime>("SentTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("SourceAddress")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("SequenceNumber");

                    b.HasIndex("EnqueueTime");

                    b.HasIndex("ExpirationTime");

                    b.HasIndex("OutboxId", "SequenceNumber")
                        .IsUnique();

                    b.HasIndex("InboxMessageId", "InboxConsumerId", "SequenceNumber")
                        .IsUnique();

                    b.ToTable("OutboxMessage", "VSPT");
                });

            modelBuilder.Entity("MassTransit.EntityFrameworkCoreIntegration.OutboxState", b =>
                {
                    b.Property<Guid>("OutboxId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("Delivered")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("LastSequenceNumber")
                        .HasColumnType("bigint");

                    b.Property<Guid>("LockId")
                        .HasColumnType("uuid");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("bytea");

                    b.HasKey("OutboxId");

                    b.HasIndex("Created");

                    b.ToTable("OutboxState", "VSPT");
                });

            modelBuilder.Entity("Vspt.BackEnd.Domain.Entity.FilialsStationsDistricts", b =>
                {
                    b.Property<string>("BuId")
                        .IsRequired()
                        .HasColumnType("character varying(4)");

                    b.Property<string>("DistrictId")
                        .IsRequired()
                        .HasColumnType("character varying(12)");

                    b.Property<string>("StationECPId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StationRZDId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasIndex("BuId");

                    b.HasIndex("DistrictId");

                    b.ToTable("FilialsStationsDistricts", "VSPT");
                });

            modelBuilder.Entity("Vspt.BackEnd.Domain.Entity.IdentityClaims", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<byte>("ClaimName")
                        .HasColumnType("smallint");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("ClaimUser")
                        .IsRequired()
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id", "ClaimName", "ClaimValue");

                    b.HasIndex("ClaimName");

                    b.HasIndex("ClaimUser");

                    b.ToTable("IdentityClaims", "VSPT");
                });

            modelBuilder.Entity("Vspt.BackEnd.Domain.Entity.IdentityRoles", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("IdentityRoles", "VSPT");
                });

            modelBuilder.Entity("Vspt.BackEnd.Domain.Entity.IdentityUsers", b =>
                {
                    b.Property<string>("Username")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("text");

                    b.Property<DateTime?>("RefreshTokenExpiryTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.Property<string>("Token")
                        .HasColumnType("text");

                    b.HasKey("Username");

                    b.ToTable("IdentityUsers", "VSPT");
                });

            modelBuilder.Entity("Vspt.BackEnd.Domain.Entity.SprDistrict", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(12)
                        .HasColumnType("character varying(12)");

                    b.Property<string>("Bu_id")
                        .IsRequired()
                        .HasColumnType("character varying(4)");

                    b.Property<string>("District_id_txt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Bu_id");

                    b.ToTable("SprDistricts", "VSPT");
                });

            modelBuilder.Entity("Vspt.BackEnd.Domain.Entity.SprFilials", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(4)
                        .HasColumnType("character varying(4)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SprFilials", "VSPT");
                });

            modelBuilder.Entity("Vspt.BackEnd.Domain.Entity.TypeClaims", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("smallint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TypeClaims", "VSPT");
                });

            modelBuilder.Entity("Vspt.BackEnd.Domain.Entity.FilialsStationsDistricts", b =>
                {
                    b.HasOne("Vspt.BackEnd.Domain.Entity.SprFilials", "Filials")
                        .WithMany()
                        .HasForeignKey("BuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vspt.BackEnd.Domain.Entity.SprDistrict", "Districts")
                        .WithMany()
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Districts");

                    b.Navigation("Filials");
                });

            modelBuilder.Entity("Vspt.BackEnd.Domain.Entity.IdentityClaims", b =>
                {
                    b.HasOne("Vspt.BackEnd.Domain.Entity.TypeClaims", "TypeClaim")
                        .WithMany()
                        .HasForeignKey("ClaimName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vspt.BackEnd.Domain.Entity.IdentityUsers", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("ClaimUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdentityUser");

                    b.Navigation("TypeClaim");
                });

            modelBuilder.Entity("Vspt.BackEnd.Domain.Entity.SprDistrict", b =>
                {
                    b.HasOne("Vspt.BackEnd.Domain.Entity.SprFilials", "SprFilial")
                        .WithMany()
                        .HasForeignKey("Bu_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SprFilial");
                });
#pragma warning restore 612, 618
        }
    }
}
