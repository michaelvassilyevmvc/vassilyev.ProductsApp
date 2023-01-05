using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiresDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CompanyName", "ExpiresDate", "Name", "ProductionDate" },
                values: new object[] { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Red Bull", null, "Monster", new DateTime(2023, 1, 14, 6, 25, 40, 627, DateTimeKind.Utc).AddTicks(8480) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CompanyName", "ExpiresDate", "Name", "ProductionDate" },
                values: new object[] { new Guid("a2b62ec8-00ff-437b-b6ef-39b68cfb2ed3"), "Балтика", new DateTime(2023, 1, 7, 6, 25, 40, 627, DateTimeKind.Utc).AddTicks(8467), "FLASH energy", new DateTime(2023, 1, 4, 6, 25, 40, 627, DateTimeKind.Utc).AddTicks(8465) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CompanyName", "ExpiresDate", "Name", "ProductionDate" },
                values: new object[] { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Gorrila", new DateTime(2023, 1, 14, 6, 25, 40, 627, DateTimeKind.Utc).AddTicks(8478), "Gorilla Energy", new DateTime(2022, 12, 22, 6, 25, 40, 627, DateTimeKind.Utc).AddTicks(8478) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
