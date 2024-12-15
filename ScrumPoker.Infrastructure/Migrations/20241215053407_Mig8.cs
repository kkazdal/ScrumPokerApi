using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScrumPoker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Mig8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "RoomUniqId",
                table: "UserRooms",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoomUniqId",
                table: "UserRooms");
        }
    }
}
