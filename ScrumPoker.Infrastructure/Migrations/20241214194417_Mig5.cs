using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ScrumPoker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Mig5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserVotes");

            migrationBuilder.DropColumn(
                name: "EstimationMethodId",
                table: "UserRooms");

            migrationBuilder.AddColumn<string>(
                name: "UserVote",
                table: "UserRooms",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EstimationMethodId",
                table: "Rooms",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserVote",
                table: "UserRooms");

            migrationBuilder.DropColumn(
                name: "EstimationMethodId",
                table: "Rooms");

            migrationBuilder.AddColumn<int>(
                name: "EstimationMethodId",
                table: "UserRooms",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserVotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TemporaryUserId = table.Column<int>(type: "integer", nullable: false),
                    UserRoomId = table.Column<int>(type: "integer", nullable: false),
                    Vote = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserVotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserVotes_TemporaryUsers_TemporaryUserId",
                        column: x => x.TemporaryUserId,
                        principalTable: "TemporaryUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserVotes_UserRooms_UserRoomId",
                        column: x => x.UserRoomId,
                        principalTable: "UserRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserVotes_TemporaryUserId",
                table: "UserVotes",
                column: "TemporaryUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserVotes_UserRoomId",
                table: "UserVotes",
                column: "UserRoomId");
        }
    }
}
