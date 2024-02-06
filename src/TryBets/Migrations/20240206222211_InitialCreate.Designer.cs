﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TryBets.Repository;

#nullable disable

namespace TryBets.Migrations
{
    [DbContext(typeof(TryBetsContext))]
    [Migration("20240206222211_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TryBets.Models.Bet", b =>
                {
                    b.Property<int>("BetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BetId"));

                    b.Property<decimal>("BetValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("MatchId")
                        .HasColumnType("int");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("BetId");

                    b.HasIndex("MatchId");

                    b.HasIndex("TeamId");

                    b.HasIndex("UserId");

                    b.ToTable("Bets");
                });

            modelBuilder.Entity("TryBets.Models.Match", b =>
                {
                    b.Property<int>("MatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MatchId"));

                    b.Property<DateTime>("MatchDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("MatchFinished")
                        .HasColumnType("bit");

                    b.Property<int>("MatchTeamAId")
                        .HasColumnType("int");

                    b.Property<decimal>("MatchTeamAValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("MatchTeamBId")
                        .HasColumnType("int");

                    b.Property<decimal>("MatchTeamBValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("MatchWinnerId")
                        .HasColumnType("int");

                    b.HasKey("MatchId");

                    b.HasIndex("MatchTeamAId");

                    b.HasIndex("MatchTeamBId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("TryBets.Models.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeamId"));

                    b.Property<string>("TeamName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeamId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("TryBets.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TryBets.Models.Bet", b =>
                {
                    b.HasOne("TryBets.Models.Match", "Match")
                        .WithMany("Bets")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TryBets.Models.Team", "Team")
                        .WithMany("Bets")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TryBets.Models.User", "User")
                        .WithMany("Bets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Match");

                    b.Navigation("Team");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TryBets.Models.Match", b =>
                {
                    b.HasOne("TryBets.Models.Team", "MatchTeamA")
                        .WithMany("MatchesA")
                        .HasForeignKey("MatchTeamAId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TryBets.Models.Team", "MatchTeamB")
                        .WithMany("MatchesB")
                        .HasForeignKey("MatchTeamBId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("MatchTeamA");

                    b.Navigation("MatchTeamB");
                });

            modelBuilder.Entity("TryBets.Models.Match", b =>
                {
                    b.Navigation("Bets");
                });

            modelBuilder.Entity("TryBets.Models.Team", b =>
                {
                    b.Navigation("Bets");

                    b.Navigation("MatchesA");

                    b.Navigation("MatchesB");
                });

            modelBuilder.Entity("TryBets.Models.User", b =>
                {
                    b.Navigation("Bets");
                });
#pragma warning restore 612, 618
        }
    }
}
