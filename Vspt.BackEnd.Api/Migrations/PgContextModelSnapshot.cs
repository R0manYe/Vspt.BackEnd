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

            modelBuilder.Entity("Vspt.BackEnd.Domain.Entity.IdentityClaims", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ClaimName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

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
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

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

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("IdentityUsers", "VSPT");
                });

            modelBuilder.Entity("Vspt.BackEnd.Domain.Entity.IdentityUsersClaims", b =>
                {
                    b.Property<Guid>("ClaimId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("ClaimValue")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ClaimId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("IdentityUsersClaims", "VSPT");
                });

            modelBuilder.Entity("Vspt.BackEnd.Domain.Entity.IdentityUsersRoles", b =>
                {
                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("RoleId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("IdentityUsersRoles", "VSPT");
                });

            modelBuilder.Entity("Vspt.BackEnd.Domain.Entity.IdentityUsersClaims", b =>
                {
                    b.HasOne("Vspt.BackEnd.Domain.Entity.IdentityClaims", "IdentityClaims")
                        .WithMany("IdentityUsersClaim")
                        .HasForeignKey("ClaimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vspt.BackEnd.Domain.Entity.IdentityUsers", "IdentityUser")
                        .WithMany("identityUsersClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdentityClaims");

                    b.Navigation("IdentityUser");
                });

            modelBuilder.Entity("Vspt.BackEnd.Domain.Entity.IdentityUsersRoles", b =>
                {
                    b.HasOne("Vspt.BackEnd.Domain.Entity.IdentityRoles", "IdentityRole")
                        .WithMany("IdentityUsersRole")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vspt.BackEnd.Domain.Entity.IdentityUsers", "IdentityUser")
                        .WithMany("IdentityUsersRole")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdentityRole");

                    b.Navigation("IdentityUser");
                });

            modelBuilder.Entity("Vspt.BackEnd.Domain.Entity.IdentityClaims", b =>
                {
                    b.Navigation("IdentityUsersClaim");
                });

            modelBuilder.Entity("Vspt.BackEnd.Domain.Entity.IdentityRoles", b =>
                {
                    b.Navigation("IdentityUsersRole");
                });

            modelBuilder.Entity("Vspt.BackEnd.Domain.Entity.IdentityUsers", b =>
                {
                    b.Navigation("IdentityUsersRole");

                    b.Navigation("identityUsersClaims");
                });
#pragma warning restore 612, 618
        }
    }
}
