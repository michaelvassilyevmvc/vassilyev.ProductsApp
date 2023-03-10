// <auto-generated />
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
    [Migration("20230104062540_Initial")]
    partial class Initial
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

                    b.Property<DateTime>("ProductionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a2b62ec8-00ff-437b-b6ef-39b68cfb2ed3"),
                            CompanyName = "Балтика",
                            ExpiresDate = new DateTime(2023, 1, 7, 6, 25, 40, 627, DateTimeKind.Utc).AddTicks(8467),
                            Name = "FLASH energy",
                            ProductionDate = new DateTime(2023, 1, 4, 6, 25, 40, 627, DateTimeKind.Utc).AddTicks(8465)
                        },
                        new
                        {
                            Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                            CompanyName = "Gorrila",
                            ExpiresDate = new DateTime(2023, 1, 14, 6, 25, 40, 627, DateTimeKind.Utc).AddTicks(8478),
                            Name = "Gorilla Energy",
                            ProductionDate = new DateTime(2022, 12, 22, 6, 25, 40, 627, DateTimeKind.Utc).AddTicks(8478)
                        },
                        new
                        {
                            Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                            CompanyName = "Red Bull",
                            Name = "Monster",
                            ProductionDate = new DateTime(2023, 1, 14, 6, 25, 40, 627, DateTimeKind.Utc).AddTicks(8480)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
