using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBrachDetailsAndCashWithdrawal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seals_Bags_BagId",
                table: "Seals");

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
                name: "AmountSinceLastEmptied",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "CurrentAmount",
                table: "Branches");

            migrationBuilder.AlterColumn<Guid>(
                name: "BagId",
                table: "Seals",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.CreateTable(
                name: "BranchCashDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BranchId = table.Column<Guid>(type: "uuid", nullable: false),
                    BagId = table.Column<Guid>(type: "uuid", nullable: false),
                    CurrentPieces = table.Column<int>(type: "integer", maxLength: 5, nullable: false),
                    CurrentAmount = table.Column<int>(type: "integer", maxLength: 9, nullable: false),
                    PiecesSinceLastEmptied = table.Column<int>(name: "PiecesSinceLastEmptied ", type: "integer", maxLength: 5, nullable: false),
                    AmountSinceLastEmptied = table.Column<int>(type: "integer", maxLength: 9, nullable: false),
                    LastEmptied = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchCashDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchCashDetails_Bags_BagId",
                        column: x => x.BagId,
                        principalTable: "Bags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchCashDetails_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CashBagWithdrawalEvents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BranchId = table.Column<Guid>(type: "uuid", nullable: false),
                    BagId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TotalPieces = table.Column<int>(type: "integer", maxLength: 5, nullable: false),
                    TotalAmount = table.Column<int>(type: "integer", maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashBagWithdrawalEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CashBagWithdrawalEvents_Bags_BagId",
                        column: x => x.BagId,
                        principalTable: "Bags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CashBagWithdrawalEvents_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CashBagWithdrawalEvents_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BranchCashDetails_BagId",
                table: "BranchCashDetails",
                column: "BagId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchCashDetails_BranchId",
                table: "BranchCashDetails",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_CashBagWithdrawalEvents_BagId",
                table: "CashBagWithdrawalEvents",
                column: "BagId");

            migrationBuilder.CreateIndex(
                name: "IX_CashBagWithdrawalEvents_BranchId",
                table: "CashBagWithdrawalEvents",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_CashBagWithdrawalEvents_UserId",
                table: "CashBagWithdrawalEvents",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seals_Bags_BagId",
                table: "Seals",
                column: "BagId",
                principalTable: "Bags",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seals_Bags_BagId",
                table: "Seals");

            migrationBuilder.DropTable(
                name: "BranchCashDetails");

            migrationBuilder.DropTable(
                name: "CashBagWithdrawalEvents");

            migrationBuilder.AlterColumn<Guid>(
                name: "BagId",
                table: "Seals",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AmountSinceLastEmptied",
                table: "Branches",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrentAmount",
                table: "Branches",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Seals_Bags_BagId",
                table: "Seals",
                column: "BagId",
                principalTable: "Bags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
