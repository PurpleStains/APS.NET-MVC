﻿// <auto-generated />
using System;
using APS.NET_MVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APS.NET_MVC.Migrations
{
    [DbContext(typeof(APSNET_MVCContext))]
    partial class APSNET_MVCContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("APS.NET_MVC.Models.Car", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarId"));

                    b.Property<string>("Brand")
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<int?>("EngineID")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("Production")
                        .HasColumnType("datetime2");

                    b.HasKey("CarId");

                    b.HasIndex("EngineID");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("APS.NET_MVC.Models.Engine", b =>
                {
                    b.Property<int>("EngineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EngineId"));

                    b.Property<int?>("Capacity")
                        .HasColumnType("int");

                    b.Property<int?>("HorsePower")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Petrol")
                        .HasColumnType("int");

                    b.HasKey("EngineId");

                    b.ToTable("Engine");
                });

            modelBuilder.Entity("APS.NET_MVC.Models.Car", b =>
                {
                    b.HasOne("APS.NET_MVC.Models.Engine", "Engine")
                        .WithMany()
                        .HasForeignKey("EngineID");

                    b.Navigation("Engine");
                });
#pragma warning restore 612, 618
        }
    }
}
