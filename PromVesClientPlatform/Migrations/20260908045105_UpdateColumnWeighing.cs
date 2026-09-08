using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PromVesClientPlatform.Migrations
{
    /// <inheritdoc />
    public partial class UpdateColumnWeighing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "WeighingDate",
                table: "Weighings",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />  
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "WeighingDate",
                table: "Weighings",
                type: "text",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }
    }
}
