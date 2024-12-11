using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScrumPoker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Mig12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "SessionId",
                table: "TemporaryUsers",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SessionId",
                table: "TemporaryUsers",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");
        }
    }
}
