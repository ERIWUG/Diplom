using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppTest.Migrations
{
    /// <inheritdoc />
    public partial class answeradd1905 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnswerType",
                table: "Answers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "isRequired",
                table: "Answers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnswerType",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "isRequired",
                table: "Answers");
        }
    }
}
