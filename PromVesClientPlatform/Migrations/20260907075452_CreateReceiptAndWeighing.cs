using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PromVesClientPlatform.Migrations
{
    /// <inheritdoc />
    public partial class CreateReceiptAndWeighing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Receipts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Operator = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weighings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupAnimals = table.Column<string>(type: "text", nullable: true),
                    Department = table.Column<string>(type: "text", nullable: true),
                    Brigade = table.Column<string>(type: "text", nullable: true),
                    ResponsibleEmployee = table.Column<string>(type: "text", nullable: true),
                    AnimalNumber = table.Column<decimal>(type: "numeric", nullable: true),
                    Quantity = table.Column<decimal>(type: "numeric", nullable: true),
                    PreviousWeigh = table.Column<decimal>(type: "numeric", nullable: true),
                    DatePreviousWeighing = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CurrentWeighing = table.Column<decimal>(type: "numeric", nullable: false),
                    WeightGain = table.Column<decimal>(type: "numeric", nullable: true),
                    WeighingDate = table.Column<string>(type: "text", nullable: false),
                    ReceiptId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weighings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weighings_Receipts_ReceiptId",
                        column: x => x.ReceiptId,
                        principalTable: "Receipts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Weighings_ReceiptId",
                table: "Weighings",
                column: "ReceiptId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weighings");

            migrationBuilder.DropTable(
                name: "Receipts");
        }
    }
}
