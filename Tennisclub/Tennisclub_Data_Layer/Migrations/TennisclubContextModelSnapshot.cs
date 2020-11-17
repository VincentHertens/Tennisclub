﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tennisclub_Data_Layer;

namespace Tennisclub_Data_Layer.Migrations
{
    [DbContext(typeof(TennisclubContext))]
    partial class TennisclubContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Tennisclub_Data_Layer.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<string>("GameNumber")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<byte>("LeagueId")
                        .HasColumnType("tinyint");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameNumber")
                        .IsUnique();

                    b.HasIndex("LeagueId");

                    b.HasIndex("MemberId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Tennisclub_Data_Layer.Models.GameResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<byte>("ScoreOpponent")
                        .HasColumnType("tinyint");

                    b.Property<byte>("ScoreTeamMember")
                        .HasColumnType("tinyint");

                    b.Property<byte>("SetNr")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("SetNr", "GameId")
                        .IsUnique();

                    b.ToTable("GameResults");
                });

            modelBuilder.Entity("Tennisclub_Data_Layer.Models.Gender", b =>
                {
                    b.Property<byte>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Genders");

                    b.HasData(
                        new
                        {
                            Id = (byte)1,
                            Name = "Man"
                        },
                        new
                        {
                            Id = (byte)2,
                            Name = "Vrouw"
                        });
                });

            modelBuilder.Entity("Tennisclub_Data_Layer.Models.League", b =>
                {
                    b.Property<byte>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Leagues");

                    b.HasData(
                        new
                        {
                            Id = (byte)1,
                            Name = "Competitie"
                        },
                        new
                        {
                            Id = (byte)2,
                            Name = "Recreatief"
                        },
                        new
                        {
                            Id = (byte)3,
                            Name = "Toptennis"
                        });
                });

            modelBuilder.Entity("Tennisclub_Data_Layer.Models.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Addition")
                        .HasColumnType("varchar(2)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("varchar(70)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("FederationNr")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(25)");

                    b.Property<byte>("GenderId")
                        .HasColumnType("tinyint");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(35)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("varchar(6)");

                    b.Property<string>("PhoneNr")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Zipcode")
                        .IsRequired()
                        .HasColumnType("varchar(6)");

                    b.HasKey("Id");

                    b.HasIndex("FederationNr")
                        .IsUnique();

                    b.HasIndex("GenderId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("Tennisclub_Data_Layer.Models.MemberFine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(7,2)");

                    b.Property<int>("FineNumber")
                        .HasColumnType("integer");

                    b.Property<DateTime>("HandoutDate")
                        .HasColumnType("date");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("PaymentDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("FineNumber")
                        .IsUnique();

                    b.HasIndex("MemberId");

                    b.ToTable("MemberFines");
                });

            modelBuilder.Entity("Tennisclub_Data_Layer.Models.MemberRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("date");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<byte>("RoleId")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("MemberId", "RoleId", "StartDate", "EndDate")
                        .IsUnique()
                        .HasFilter("[EndDate] IS NOT NULL");

                    b.ToTable("MemberRoles");
                });

            modelBuilder.Entity("Tennisclub_Data_Layer.Models.Role", b =>
                {
                    b.Property<byte>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = (byte)1,
                            Name = "Bestuurslid"
                        },
                        new
                        {
                            Id = (byte)2,
                            Name = "Penningmeester"
                        },
                        new
                        {
                            Id = (byte)3,
                            Name = "Secretaris"
                        },
                        new
                        {
                            Id = (byte)4,
                            Name = "Speler"
                        },
                        new
                        {
                            Id = (byte)5,
                            Name = "Voorzitter"
                        });
                });

            modelBuilder.Entity("Tennisclub_Data_Layer.Models.Game", b =>
                {
                    b.HasOne("Tennisclub_Data_Layer.Models.League", "League")
                        .WithMany()
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tennisclub_Data_Layer.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tennisclub_Data_Layer.Models.GameResult", b =>
                {
                    b.HasOne("Tennisclub_Data_Layer.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tennisclub_Data_Layer.Models.Member", b =>
                {
                    b.HasOne("Tennisclub_Data_Layer.Models.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tennisclub_Data_Layer.Models.MemberFine", b =>
                {
                    b.HasOne("Tennisclub_Data_Layer.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tennisclub_Data_Layer.Models.MemberRole", b =>
                {
                    b.HasOne("Tennisclub_Data_Layer.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tennisclub_Data_Layer.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
