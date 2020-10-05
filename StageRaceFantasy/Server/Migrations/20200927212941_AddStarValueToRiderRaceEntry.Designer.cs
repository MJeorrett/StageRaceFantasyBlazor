﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StageRaceFantasy.Server.Db;

namespace StageRaceFantasy.Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200927212941_AddStarValueToRiderRaceEntry")]
    partial class AddStarValueToRiderRaceEntry
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0-rc.1.20451.13");

            modelBuilder.Entity("StageRaceFantasy.Shared.Models.FantasyTeam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FantasyTeams");
                });

            modelBuilder.Entity("StageRaceFantasy.Shared.Models.FantasyTeamRaceEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("FantasyTeamId")
                        .HasColumnType("int");

                    b.Property<int>("RaceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasAlternateKey("FantasyTeamId", "RaceId");

                    b.HasIndex("RaceId");

                    b.ToTable("FantasyTeamRaceEntries");
                });

            modelBuilder.Entity("StageRaceFantasy.Shared.Models.FantasyTeamRaceEntryRider", b =>
                {
                    b.Property<int>("FantasyTeamRaceEntryId")
                        .HasColumnType("int");

                    b.Property<int>("RiderId")
                        .HasColumnType("int");

                    b.HasKey("FantasyTeamRaceEntryId", "RiderId");

                    b.HasIndex("RiderId");

                    b.ToTable("FantasyTeamRaceEntryRider");
                });

            modelBuilder.Entity("StageRaceFantasy.Shared.Models.Race", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Races");
                });

            modelBuilder.Entity("StageRaceFantasy.Shared.Models.Rider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Riders");
                });

            modelBuilder.Entity("StageRaceFantasy.Shared.Models.RiderRaceEntry", b =>
                {
                    b.Property<int>("RaceId")
                        .HasColumnType("int");

                    b.Property<int>("RiderId")
                        .HasColumnType("int");

                    b.Property<int>("BibNumber")
                        .HasColumnType("int");

                    b.Property<int>("StarValue")
                        .HasColumnType("int");

                    b.HasKey("RaceId", "RiderId");

                    b.HasIndex("RiderId");

                    b.ToTable("RiderRaceEntries");
                });

            modelBuilder.Entity("StageRaceFantasy.Shared.Models.FantasyTeamRaceEntry", b =>
                {
                    b.HasOne("StageRaceFantasy.Shared.Models.FantasyTeam", "FantasyTeam")
                        .WithMany("RaceEntries")
                        .HasForeignKey("FantasyTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StageRaceFantasy.Shared.Models.Race", "Race")
                        .WithMany()
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FantasyTeam");

                    b.Navigation("Race");
                });

            modelBuilder.Entity("StageRaceFantasy.Shared.Models.FantasyTeamRaceEntryRider", b =>
                {
                    b.HasOne("StageRaceFantasy.Shared.Models.FantasyTeamRaceEntry", "FantasyTeamRaceEntry")
                        .WithMany("FantasyTeamRaceEntryRiders")
                        .HasForeignKey("FantasyTeamRaceEntryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StageRaceFantasy.Shared.Models.Rider", "Rider")
                        .WithMany("FantasyTeamRaceEntryRiders")
                        .HasForeignKey("RiderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FantasyTeamRaceEntry");

                    b.Navigation("Rider");
                });

            modelBuilder.Entity("StageRaceFantasy.Shared.Models.RiderRaceEntry", b =>
                {
                    b.HasOne("StageRaceFantasy.Shared.Models.Race", "Race")
                        .WithMany("RiderEntries")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StageRaceFantasy.Shared.Models.Rider", "Rider")
                        .WithMany()
                        .HasForeignKey("RiderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Race");

                    b.Navigation("Rider");
                });

            modelBuilder.Entity("StageRaceFantasy.Shared.Models.FantasyTeam", b =>
                {
                    b.Navigation("RaceEntries");
                });

            modelBuilder.Entity("StageRaceFantasy.Shared.Models.FantasyTeamRaceEntry", b =>
                {
                    b.Navigation("FantasyTeamRaceEntryRiders");
                });

            modelBuilder.Entity("StageRaceFantasy.Shared.Models.Race", b =>
                {
                    b.Navigation("RiderEntries");
                });

            modelBuilder.Entity("StageRaceFantasy.Shared.Models.Rider", b =>
                {
                    b.Navigation("FantasyTeamRaceEntryRiders");
                });
#pragma warning restore 612, 618
        }
    }
}