﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TreePlant.Database.DatabaseContext;

#nullable disable

namespace TreePlant.Database.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230128100341_firstMigration")]
    partial class firstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TreePlant.Database.Entities.AreaDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Size")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("TreePlant.Database.Entities.PlantedTreeDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AreaId")
                        .HasColumnType("int");

                    b.Property<int>("TreeSortId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.HasIndex("TreeSortId");

                    b.ToTable("PlantedTrees");
                });

            modelBuilder.Entity("TreePlant.Database.Entities.TreeSortDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BearingAge")
                        .HasColumnType("int");

                    b.Property<double>("GrowthRateCm")
                        .HasColumnType("float");

                    b.Property<int>("HarvestTime")
                        .HasColumnType("int");

                    b.Property<double>("MatureHeight")
                        .HasColumnType("float");

                    b.Property<double>("MatureWidth")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("SoilType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SunExposure")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TreeTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TreeTypeId");

                    b.ToTable("TreeSorts");
                });

            modelBuilder.Entity("TreePlant.Database.Entities.TreeTypeDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("TreeTypes");
                });

            modelBuilder.Entity("TreePlant.Database.Entities.PlantedTreeDb", b =>
                {
                    b.HasOne("TreePlant.Database.Entities.AreaDb", "Area")
                        .WithMany("Trees")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TreePlant.Database.Entities.TreeSortDb", "TreeSort")
                        .WithMany()
                        .HasForeignKey("TreeSortId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area");

                    b.Navigation("TreeSort");
                });

            modelBuilder.Entity("TreePlant.Database.Entities.TreeSortDb", b =>
                {
                    b.HasOne("TreePlant.Database.Entities.TreeTypeDb", "TreeType")
                        .WithMany("TreeSorts")
                        .HasForeignKey("TreeTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TreeType");
                });

            modelBuilder.Entity("TreePlant.Database.Entities.AreaDb", b =>
                {
                    b.Navigation("Trees");
                });

            modelBuilder.Entity("TreePlant.Database.Entities.TreeTypeDb", b =>
                {
                    b.Navigation("TreeSorts");
                });
#pragma warning restore 612, 618
        }
    }
}