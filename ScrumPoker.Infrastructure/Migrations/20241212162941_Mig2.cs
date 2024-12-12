using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScrumPoker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TemporaryUserId",
                table: "UserVotes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserVotes_TemporaryUserId",
                table: "UserVotes",
                column: "TemporaryUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserVotes_TemporaryUsers_TemporaryUserId",
                table: "UserVotes",
                column: "TemporaryUserId",
                principalTable: "TemporaryUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserVotes_TemporaryUsers_TemporaryUserId",
                table: "UserVotes");

            migrationBuilder.DropIndex(
                name: "IX_UserVotes_TemporaryUserId",
                table: "UserVotes");

            migrationBuilder.DropColumn(
                name: "TemporaryUserId",
                table: "UserVotes");
        }
    }
}
