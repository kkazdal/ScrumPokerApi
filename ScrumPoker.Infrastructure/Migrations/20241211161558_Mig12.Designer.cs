﻿// <auto-generated />
using System;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ScrumPoker.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241211161558_Mig12")]
    partial class Mig12
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ScrumPoker.Domain.Entities.TemporaryUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("JoinedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("SessionId")
                        .HasColumnType("uuid");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TemporaryUsers");
                });

            modelBuilder.Entity("ScrumPoker.Domain.Entities.UserRoom", b =>
                {
                    b.Property<int>("UserRoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserRoomId"));

                    b.Property<bool>("IsHost")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("JoinedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("RoomId")
                        .HasColumnType("integer");

                    b.Property<int?>("TempUserId")
                        .HasColumnType("integer");

                    b.HasKey("UserRoomId");

                    b.HasIndex("RoomId");

                    b.HasIndex("TempUserId");

                    b.ToTable("UserRooms");
                });

            modelBuilder.Entity("ScrumPoker.Domain.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("RoomName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("RoomUniqId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("ScrumPoker.Domain.Entities.UserRoom", b =>
                {
                    b.HasOne("ScrumPoker.Domain.Room", "Room")
                        .WithMany("UserRooms")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScrumPoker.Domain.Entities.TemporaryUser", "TempUser")
                        .WithMany("UserRooms")
                        .HasForeignKey("TempUserId");

                    b.Navigation("Room");

                    b.Navigation("TempUser");
                });

            modelBuilder.Entity("ScrumPoker.Domain.Entities.TemporaryUser", b =>
                {
                    b.Navigation("UserRooms");
                });

            modelBuilder.Entity("ScrumPoker.Domain.Room", b =>
                {
                    b.Navigation("UserRooms");
                });
#pragma warning restore 612, 618
        }
    }
}
