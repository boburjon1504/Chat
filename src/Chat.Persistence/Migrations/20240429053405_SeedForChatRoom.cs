using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chat.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedForChatRoom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ChatRooms",
                columns: new[] { "Id", "FirstUserId", "SecondUserId" },
                values: new object[] { new Guid("141a18b0-9f76-4494-bd76-5d92a63891e7"), new Guid("d288a320-adb3-4018-b6ce-449a124775fd"), new Guid("5dff9d04-9a72-4cb8-bc73-63ad04078d2d") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ChatRooms",
                keyColumn: "Id",
                keyValue: new Guid("141a18b0-9f76-4494-bd76-5d92a63891e7"));
        }
    }
}
