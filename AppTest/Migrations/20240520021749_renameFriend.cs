using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppTest.Migrations
{
    /// <inheritdoc />
    public partial class renameFriend : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friends");

            migrationBuilder.AddColumn<int>(
                name: "UserEntityId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserEntityId",
                table: "Users",
                column: "UserEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_UserEntityId",
                table: "Users",
                column: "UserEntityId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_UserEntityId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserEntityId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserEntityId",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    User1ID = table.Column<int>(type: "int", nullable: false),
                    User2ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => new { x.User1ID, x.User2ID });
                    table.ForeignKey(
                        name: "FK_Friends_Users_User1ID",
                        column: x => x.User1ID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Friends_Users_User2ID",
                        column: x => x.User2ID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Friends_User2ID",
                table: "Friends",
                column: "User2ID");
        }
    }
}
