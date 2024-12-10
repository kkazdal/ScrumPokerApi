using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScrumPoker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Mig6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoom_RegisteredUser_UserId",
                table: "UserRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoom_Room_RoomId",
                table: "UserRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoom_TemporaryUser_TempUserId",
                table: "UserRoom");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoom",
                table: "UserRoom");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TemporaryUser",
                table: "TemporaryUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Room",
                table: "Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegisteredUser",
                table: "RegisteredUser");

            migrationBuilder.RenameTable(
                name: "UserRoom",
                newName: "UserRooms");

            migrationBuilder.RenameTable(
                name: "TemporaryUser",
                newName: "TemporaryUsers");

            migrationBuilder.RenameTable(
                name: "Room",
                newName: "Rooms");

            migrationBuilder.RenameTable(
                name: "RegisteredUser",
                newName: "RegisteredUsers");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoom_UserId",
                table: "UserRooms",
                newName: "IX_UserRooms_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoom_TempUserId",
                table: "UserRooms",
                newName: "IX_UserRooms_TempUserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoom_RoomId",
                table: "UserRooms",
                newName: "IX_UserRooms_RoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRooms",
                table: "UserRooms",
                column: "UserRoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TemporaryUsers",
                table: "TemporaryUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegisteredUsers",
                table: "RegisteredUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRooms_RegisteredUsers_UserId",
                table: "UserRooms",
                column: "UserId",
                principalTable: "RegisteredUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRooms_Rooms_RoomId",
                table: "UserRooms",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRooms_TemporaryUsers_TempUserId",
                table: "UserRooms",
                column: "TempUserId",
                principalTable: "TemporaryUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRooms_RegisteredUsers_UserId",
                table: "UserRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRooms_Rooms_RoomId",
                table: "UserRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRooms_TemporaryUsers_TempUserId",
                table: "UserRooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRooms",
                table: "UserRooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TemporaryUsers",
                table: "TemporaryUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegisteredUsers",
                table: "RegisteredUsers");

            migrationBuilder.RenameTable(
                name: "UserRooms",
                newName: "UserRoom");

            migrationBuilder.RenameTable(
                name: "TemporaryUsers",
                newName: "TemporaryUser");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "Room");

            migrationBuilder.RenameTable(
                name: "RegisteredUsers",
                newName: "RegisteredUser");

            migrationBuilder.RenameIndex(
                name: "IX_UserRooms_UserId",
                table: "UserRoom",
                newName: "IX_UserRoom_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRooms_TempUserId",
                table: "UserRoom",
                newName: "IX_UserRoom_TempUserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRooms_RoomId",
                table: "UserRoom",
                newName: "IX_UserRoom_RoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoom",
                table: "UserRoom",
                column: "UserRoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TemporaryUser",
                table: "TemporaryUser",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Room",
                table: "Room",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegisteredUser",
                table: "RegisteredUser",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoom_RegisteredUser_UserId",
                table: "UserRoom",
                column: "UserId",
                principalTable: "RegisteredUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoom_Room_RoomId",
                table: "UserRoom",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoom_TemporaryUser_TempUserId",
                table: "UserRoom",
                column: "TempUserId",
                principalTable: "TemporaryUser",
                principalColumn: "Id");
        }
    }
}
