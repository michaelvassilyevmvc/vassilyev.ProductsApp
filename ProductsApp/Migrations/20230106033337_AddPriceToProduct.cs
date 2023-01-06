using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsApp.Migrations
{
    public partial class AddPriceToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                column: "ProductionDate",
                value: new DateTime(2023, 1, 16, 3, 33, 37, 534, DateTimeKind.Utc).AddTicks(6312));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("a2b62ec8-00ff-437b-b6ef-39b68cfb2ed3"),
                columns: new[] { "ExpiresDate", "ProductionDate" },
                values: new object[] { new DateTime(2023, 1, 9, 3, 33, 37, 534, DateTimeKind.Utc).AddTicks(6301), new DateTime(2023, 1, 6, 3, 33, 37, 534, DateTimeKind.Utc).AddTicks(6299) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                columns: new[] { "ExpiresDate", "ProductionDate" },
                values: new object[] { new DateTime(2023, 1, 16, 3, 33, 37, 534, DateTimeKind.Utc).AddTicks(6310), new DateTime(2022, 12, 24, 3, 33, 37, 534, DateTimeKind.Utc).AddTicks(6309) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                column: "ProductionDate",
                value: new DateTime(2023, 1, 14, 6, 25, 40, 627, DateTimeKind.Utc).AddTicks(8480));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("a2b62ec8-00ff-437b-b6ef-39b68cfb2ed3"),
                columns: new[] { "ExpiresDate", "ProductionDate" },
                values: new object[] { new DateTime(2023, 1, 7, 6, 25, 40, 627, DateTimeKind.Utc).AddTicks(8467), new DateTime(2023, 1, 4, 6, 25, 40, 627, DateTimeKind.Utc).AddTicks(8465) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                columns: new[] { "ExpiresDate", "ProductionDate" },
                values: new object[] { new DateTime(2023, 1, 14, 6, 25, 40, 627, DateTimeKind.Utc).AddTicks(8478), new DateTime(2022, 12, 22, 6, 25, 40, 627, DateTimeKind.Utc).AddTicks(8478) });
        }
    }
}
