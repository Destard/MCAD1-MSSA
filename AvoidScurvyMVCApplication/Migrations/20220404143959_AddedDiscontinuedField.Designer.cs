﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AvoidScurvyMVCApplication.Migrations
{
    [DbContext(typeof(AvoidScurvyContext))]
    [Migration("20220404143959_AddedDiscontinuedField")]
    partial class AddedDiscontinuedField
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AvoidScurvyMVCApplication.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductID"), 1L, 1);

                    b.Property<int>("Calories")
                        .HasColumnType("int");

                    b.Property<bool>("IsDiscontinued")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("StarRating")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UPC")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VitCDailyAmount")
                        .HasColumnType("int");

                    b.HasKey("ProductID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("AvoidScurvyMVCApplication.Models.ProductViewing", b =>
                {
                    b.Property<int>("ProductViewingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductViewingId"), 1L, 1);

                    b.Property<decimal>("PricePerServing")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("StoreName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ViewingTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ProductViewingId");

                    b.ToTable("ProductViewings");
                });
#pragma warning restore 612, 618
        }
    }
}
