﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Data;

#nullable disable

namespace WebAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220408185833_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebAPI.Models.Domain.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double?>("Area")
                        .HasColumnType("float");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Lat")
                        .HasColumnType("float");

                    b.Property<double?>("Long")
                        .HasColumnType("float");

                    b.Property<long?>("Population")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("WebAPI.Models.Domain.Walk", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double?>("Length")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WalkDifficultyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WalkDifficulytId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.HasIndex("WalkDifficultyId");

                    b.ToTable("Walks");
                });

            modelBuilder.Entity("WebAPI.Models.Domain.WalkDifficulty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WalkDifficulties");
                });

            modelBuilder.Entity("WebAPI.Models.Domain.Walk", b =>
                {
                    b.HasOne("WebAPI.Models.Domain.Region", "Region")
                        .WithMany("Walks")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPI.Models.Domain.WalkDifficulty", "WalkDifficulty")
                        .WithMany()
                        .HasForeignKey("WalkDifficultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");

                    b.Navigation("WalkDifficulty");
                });

            modelBuilder.Entity("WebAPI.Models.Domain.Region", b =>
                {
                    b.Navigation("Walks");
                });
#pragma warning restore 612, 618
        }
    }
}
