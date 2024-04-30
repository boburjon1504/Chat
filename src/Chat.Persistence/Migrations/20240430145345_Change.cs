using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Chat.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Change : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ChatRooms_FirstUserId",
                table: "ChatRooms");

            migrationBuilder.DropIndex(
                name: "IX_ChatRooms_SecondUserId",
                table: "ChatRooms");

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: new Guid("2633573d-e18d-4726-8b87-46a0d3b8b188"));

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: new Guid("8ee8d6f9-2ba4-446c-998d-368b33354f05"));

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "Body", "ChatId", "IsDelivered", "ReceiverId", "SendAt", "SenderId" },
                values: new object[,]
                {
                    { new Guid("beaeffe3-6f99-4a09-ae08-cd292afd522c"), "Salom", null, true, new Guid("d288a320-adb3-4018-b6ce-449a124775fd"), new DateTimeOffset(new DateTime(2024, 4, 30, 14, 53, 43, 631, DateTimeKind.Unspecified).AddTicks(9792), new TimeSpan(0, 0, 0, 0, 0)), new Guid("5dff9d04-9a72-4cb8-bc73-63ad04078d2d") },
                    { new Guid("c0784785-b0b4-4e6a-9cd0-af47f822c1ee"), "Ishlaring yaxshimi", null, true, new Guid("5dff9d04-9a72-4cb8-bc73-63ad04078d2d"), new DateTimeOffset(new DateTime(2024, 4, 30, 19, 53, 43, 631, DateTimeKind.Unspecified).AddTicks(9838), new TimeSpan(0, 5, 0, 0, 0)), new Guid("d288a320-adb3-4018-b6ce-449a124775fd") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatRooms_FirstUserId",
                table: "ChatRooms",
                column: "FirstUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatRooms_SecondUserId",
                table: "ChatRooms",
                column: "SecondUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ChatRooms_FirstUserId",
                table: "ChatRooms");

            migrationBuilder.DropIndex(
                name: "IX_ChatRooms_SecondUserId",
                table: "ChatRooms");

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: new Guid("beaeffe3-6f99-4a09-ae08-cd292afd522c"));

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: new Guid("c0784785-b0b4-4e6a-9cd0-af47f822c1ee"));

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "Body", "ChatId", "IsDelivered", "ReceiverId", "SendAt", "SenderId" },
                values: new object[,]
                {
                    { new Guid("2633573d-e18d-4726-8b87-46a0d3b8b188"), "Ishlaring yaxshimi", null, true, new Guid("5dff9d04-9a72-4cb8-bc73-63ad04078d2d"), new DateTimeOffset(new DateTime(2024, 4, 30, 0, 31, 23, 601, DateTimeKind.Unspecified).AddTicks(9317), new TimeSpan(0, 5, 0, 0, 0)), new Guid("d288a320-adb3-4018-b6ce-449a124775fd") },
                    { new Guid("8ee8d6f9-2ba4-446c-998d-368b33354f05"), "Salom", null, true, new Guid("d288a320-adb3-4018-b6ce-449a124775fd"), new DateTimeOffset(new DateTime(2024, 4, 29, 19, 31, 23, 601, DateTimeKind.Unspecified).AddTicks(9274), new TimeSpan(0, 0, 0, 0, 0)), new Guid("5dff9d04-9a72-4cb8-bc73-63ad04078d2d") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatRooms_FirstUserId",
                table: "ChatRooms",
                column: "FirstUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChatRooms_SecondUserId",
                table: "ChatRooms",
                column: "SecondUserId",
                unique: true);
        }
    }
}
