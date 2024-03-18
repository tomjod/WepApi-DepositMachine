using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DepositMachine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("5c54ad6b-1626-49ff-a7a0-e7b54375c75f"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7d363a05-7fc5-4ffc-9f25-75fa845b075b"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("979c3a74-3d3e-4f80-8699-a6c0a502823c"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a07bd4fb-c2c0-4699-a9db-19a66c43cc4c"));

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "DepositMachines",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("864ae09d-5c28-485c-97b5-9be0bed0c69f"), null, "Administrator", "ADMINISTRATOR" },
                    { new Guid("a20aec05-edd6-4118-a4db-b45409a2554e"), null, "Supervisor", "SUPERVISOR" },
                    { new Guid("b1128788-67d0-4b7d-9d00-5af50f65e248"), null, "Tesorero", "TESORERO" },
                    { new Guid("e16411b5-c09e-4a34-ae53-53c641e737f3"), null, "Vigilante", "VIGILANTE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("864ae09d-5c28-485c-97b5-9be0bed0c69f"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a20aec05-edd6-4118-a4db-b45409a2554e"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b1128788-67d0-4b7d-9d00-5af50f65e248"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("e16411b5-c09e-4a34-ae53-53c641e737f3"));

            migrationBuilder.DropColumn(
                name: "Model",
                table: "DepositMachines");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("5c54ad6b-1626-49ff-a7a0-e7b54375c75f"), null, "Administrator", "ADMINISTRATOR" },
                    { new Guid("7d363a05-7fc5-4ffc-9f25-75fa845b075b"), null, "Vigilante", "VIGILANTE" },
                    { new Guid("979c3a74-3d3e-4f80-8699-a6c0a502823c"), null, "Supervisor", "SUPERVISOR" },
                    { new Guid("a07bd4fb-c2c0-4699-a9db-19a66c43cc4c"), null, "Tesorero", "TESORERO" }
                });
        }
    }
}
