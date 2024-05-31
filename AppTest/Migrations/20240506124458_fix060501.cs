using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppTest.Migrations
{
    /// <inheritdoc />
    public partial class fix060501 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CountryRequirement",
                table: "Tests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxAge",
                table: "Tests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinAge",
                table: "Tests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TownRequirement",
                table: "Tests",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryRequirement",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "MaxAge",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "MinAge",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "TownRequirement",
                table: "Tests");
        }
    }
}
