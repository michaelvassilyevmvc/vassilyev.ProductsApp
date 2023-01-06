﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

#nullable disable

namespace ProductsApp.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20230106033337_AddPriceToProduct")]
    partial class AddPriceToProduct
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ProductId");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ExpiresDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ProductionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a2b62ec8-00ff-437b-b6ef-39b68cfb2ed3"),
                            CompanyName = "Балтика",
                            ExpiresDate = new DateTime(2023, 1, 9, 3, 33, 37, 534, DateTimeKind.Utc).AddTicks(6301),
                            Name = "FLASH energy",
                            ProductionDate = new DateTime(2023, 1, 6, 3, 33, 37, 534, DateTimeKind.Utc).AddTicks(6299)
                        },
                        new
                        {
                            Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                            CompanyName = "Gorrila",
                            ExpiresDate = new DateTime(2023, 1, 16, 3, 33, 37, 534, DateTimeKind.Utc).AddTicks(6310),
                            Name = "Gorilla Energy",
                            ProductionDate = new DateTime(2022, 12, 24, 3, 33, 37, 534, DateTimeKind.Utc).AddTicks(6309)
                        },
                        new
                        {
                            Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                            CompanyName = "Red Bull",
                            Name = "Monster",
                            ProductionDate = new DateTime(2023, 1, 16, 3, 33, 37, 534, DateTimeKind.Utc).AddTicks(6312)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
