using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ScrumPoker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Mig10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRooms_RegisteredUsers_UserId",
                table: "UserRooms");

            migrationBuilder.DropTable(
                name: "RegisteredUsers");

            migrationBuilder.DropIndex(
                name: "IX_UserRooms_UserId",
                table: "UserRooms");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserRooms");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserRooms",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RegisteredUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisteredUsers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRooms_UserId",
                table: "UserRooms",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRooms_RegisteredUsers_UserId",
                table: "UserRooms",
                column: "UserId",
                principalTable: "RegisteredUsers",
                principalColumn: "Id");
        }
    }
}
