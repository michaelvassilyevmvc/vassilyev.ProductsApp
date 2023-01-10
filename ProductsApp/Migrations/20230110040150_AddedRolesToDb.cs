using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsApp.Migrations
{
    public partial class AddedRolesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0f67e2c6-fa2f-439d-acd2-bd384d7e5e94", "63649181-edcd-4348-8f03-2c578e243db7", "Administrator", "ADMINISTRATOR" },
                    { "818f4286-323e-466c-8ef9-3e1a6d12547d", "af87f75b-5a3d-4940-8ccb-09564611306d", "Manager", "MANAGER" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                column: "ProductionDate",
                value: new DateTime(2023, 1, 20, 4, 1, 50, 659, DateTimeKind.Utc).AddTicks(8837));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("a2b62ec8-00ff-437b-b6ef-39b68cfb2ed3"),
                columns: new[] { "ExpiresDate", "ProductionDate" },
                values: new object[] { new DateTime(2023, 1, 13, 4, 1, 50, 659, DateTimeKind.Utc).AddTicks(8824), new DateTime(2023, 1, 10, 4, 1, 50, 659, DateTimeKind.Utc).AddTicks(8823) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                columns: new[] { "ExpiresDate", "ProductionDate" },
                values: new object[] { new DateTime(2023, 1, 20, 4, 1, 50, 659, DateTimeKind.Utc).AddTicks(8834), new DateTime(2022, 12, 28, 4, 1, 50, 659, DateTimeKind.Utc).AddTicks(8834) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f67e2c6-fa2f-439d-acd2-bd384d7e5e94");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "818f4286-323e-466c-8ef9-3e1a6d12547d");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                column: "ProductionDate",
                value: new DateTime(2023, 1, 20, 3, 54, 9, 55, DateTimeKind.Utc).AddTicks(2007));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("a2b62ec8-00ff-437b-b6ef-39b68cfb2ed3"),
                columns: new[] { "ExpiresDate", "ProductionDate" },
                values: new object[] { new DateTime(2023, 1, 13, 3, 54, 9, 55, DateTimeKind.Utc).AddTicks(1996), new DateTime(2023, 1, 10, 3, 54, 9, 55, DateTimeKind.Utc).AddTicks(1994) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                columns: new[] { "ExpiresDate", "ProductionDate" },
                values: new object[] { new DateTime(2023, 1, 20, 3, 54, 9, 55, DateTimeKind.Utc).AddTicks(2005), new DateTime(2022, 12, 28, 3, 54, 9, 55, DateTimeKind.Utc).AddTicks(2005) });
        }
    }
}
