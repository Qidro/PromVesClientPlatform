using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PromVesClientPlatform.Migrations
{
    /// <inheritdoc />
    public partial class updateWeighingModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PreviousWeigh",
                table: "Weighings",
                newName: "QuantityOld");

            migrationBuilder.AddColumn<decimal>(
                name: "CurrentWeighingOld",
                table: "Weighings",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WeightGainOld",
                table: "Weighings",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentWeighingOld",
                table: "Weighings");

            migrationBuilder.DropColumn(
                name: "WeightGainOld",
                table: "Weighings");

            migrationBuilder.RenameColumn(
                name: "QuantityOld",
                table: "Weighings",
                newName: "PreviousWeigh");
        }
    }
}
