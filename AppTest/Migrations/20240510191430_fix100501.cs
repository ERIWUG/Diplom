using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppTest.Migrations
{
    /// <inheritdoc />
    public partial class fix100501 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswerEntityTestResultEntity_TestResultEntity_ResultsId",
                table: "AnswerEntityTestResultEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_TestResultEntity_Tests_TestId",
                table: "TestResultEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_TestResultEntity_Users_UserId",
                table: "TestResultEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestResultEntity",
                table: "TestResultEntity");

            migrationBuilder.RenameTable(
                name: "TestResultEntity",
                newName: "TestResults");

            migrationBuilder.RenameIndex(
                name: "IX_TestResultEntity_UserId",
                table: "TestResults",
                newName: "IX_TestResults_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TestResultEntity_TestId",
                table: "TestResults",
                newName: "IX_TestResults_TestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestResults",
                table: "TestResults",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerEntityTestResultEntity_TestResults_ResultsId",
                table: "AnswerEntityTestResultEntity",
                column: "ResultsId",
                principalTable: "TestResults",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestResults_Tests_TestId",
                table: "TestResults",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TestResults_Users_UserId",
                table: "TestResults",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswerEntityTestResultEntity_TestResults_ResultsId",
                table: "AnswerEntityTestResultEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_TestResults_Tests_TestId",
                table: "TestResults");

            migrationBuilder.DropForeignKey(
                name: "FK_TestResults_Users_UserId",
                table: "TestResults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestResults",
                table: "TestResults");

            migrationBuilder.RenameTable(
                name: "TestResults",
                newName: "TestResultEntity");

            migrationBuilder.RenameIndex(
                name: "IX_TestResults_UserId",
                table: "TestResultEntity",
                newName: "IX_TestResultEntity_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TestResults_TestId",
                table: "TestResultEntity",
                newName: "IX_TestResultEntity_TestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestResultEntity",
                table: "TestResultEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerEntityTestResultEntity_TestResultEntity_ResultsId",
                table: "AnswerEntityTestResultEntity",
                column: "ResultsId",
                principalTable: "TestResultEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestResultEntity_Tests_TestId",
                table: "TestResultEntity",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TestResultEntity_Users_UserId",
                table: "TestResultEntity",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
