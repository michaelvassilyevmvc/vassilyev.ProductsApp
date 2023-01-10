using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsApp.Migrations
{
    public partial class AdditionalUserFiledsForRefreshToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f67e2c6-fa2f-439d-acd2-bd384d7e5e94");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "818f4286-323e-466c-8ef9-3e1a6d12547d");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "39d6dd51-bb1a-4f60-bdeb-17ec023c9b1a", "8ed7fd5c-3307-4915-ae49-fc650b4317b5", "Manager", "MANAGER" },
                    { "96430217-1cbf-43b8-9784-ba2f446acd16", "7a31a0b3-a045-40b8-9c68-a0c64c42090a", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                column: "ProductionDate",
                value: new DateTime(2023, 1, 20, 8, 27, 49, 189, DateTimeKind.Utc).AddTicks(7786));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("a2b62ec8-00ff-437b-b6ef-39b68cfb2ed3"),
                columns: new[] { "ExpiresDate", "ProductionDate" },
                values: new object[] { new DateTime(2023, 1, 13, 8, 27, 49, 189, DateTimeKind.Utc).AddTicks(7770), new DateTime(2023, 1, 10, 8, 27, 49, 189, DateTimeKind.Utc).AddTicks(7768) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                columns: new[] { "ExpiresDate", "ProductionDate" },
                values: new object[] { new DateTime(2023, 1, 20, 8, 27, 49, 189, DateTimeKind.Utc).AddTicks(7784), new DateTime(2022, 12, 28, 8, 27, 49, 189, DateTimeKind.Utc).AddTicks(7783) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39d6dd51-bb1a-4f60-bdeb-17ec023c9b1a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "96430217-1cbf-43b8-9784-ba2f446acd16");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers");

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
    }
}
