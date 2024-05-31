using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppTest.Migrations
{
    /// <inheritdoc />
    public partial class commentfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserPages_UserId",
                table: "UserPages");

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_UserPages_UserId",
                table: "UserPages",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserPages_UserId",
                table: "UserPages");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Comments");

            migrationBuilder.CreateIndex(
                name: "IX_UserPages_UserId",
                table: "UserPages",
                column: "UserId");
        }
    }
}
