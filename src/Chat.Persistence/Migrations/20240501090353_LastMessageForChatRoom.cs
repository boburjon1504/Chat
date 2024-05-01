using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Chat.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class LastMessageForChatRoom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ChatRooms",
                keyColumn: "Id",
                keyValue: new Guid("141a18b0-9f76-4494-bd76-5d92a63891e7"));

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: new Guid("beaeffe3-6f99-4a09-ae08-cd292afd522c"));

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: new Guid("c0784785-b0b4-4e6a-9cd0-af47f822c1ee"));

            migrationBuilder.AddColumn<Guid>(
                name: "LastMessageId",
                table: "ChatRooms",
                type: "uuid",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "Body", "ChatId", "IsDelivered", "ReceiverId", "SendAt", "SenderId" },
                values: new object[,]
                {
                    { new Guid("7218b486-c370-4339-a506-4bbcd6d60f57"), "Salom", null, true, new Guid("d288a320-adb3-4018-b6ce-449a124775fd"), new DateTimeOffset(new DateTime(2024, 5, 1, 9, 3, 53, 130, DateTimeKind.Unspecified).AddTicks(7831), new TimeSpan(0, 0, 0, 0, 0)), new Guid("5dff9d04-9a72-4cb8-bc73-63ad04078d2d") },
                    { new Guid("d5032e60-9595-4124-b17f-fb6f32c49be9"), "Ishlaring yaxshimi", null, true, new Guid("5dff9d04-9a72-4cb8-bc73-63ad04078d2d"), new DateTimeOffset(new DateTime(2024, 5, 1, 14, 3, 53, 130, DateTimeKind.Unspecified).AddTicks(7869), new TimeSpan(0, 5, 0, 0, 0)), new Guid("d288a320-adb3-4018-b6ce-449a124775fd") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatRooms_LastMessageId",
                table: "ChatRooms",
                column: "LastMessageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatRooms_Messages_LastMessageId",
                table: "ChatRooms",
                column: "LastMessageId",
                principalTable: "Messages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatRooms_Messages_LastMessageId",
                table: "ChatRooms");

            migrationBuilder.DropIndex(
                name: "IX_ChatRooms_LastMessageId",
                table: "ChatRooms");

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: new Guid("7218b486-c370-4339-a506-4bbcd6d60f57"));

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: new Guid("d5032e60-9595-4124-b17f-fb6f32c49be9"));

            migrationBuilder.DropColumn(
                name: "LastMessageId",
                table: "ChatRooms");

            migrationBuilder.InsertData(
                table: "ChatRooms",
                columns: new[] { "Id", "FirstUserId", "SecondUserId" },
                values: new object[] { new Guid("141a18b0-9f76-4494-bd76-5d92a63891e7"), new Guid("d288a320-adb3-4018-b6ce-449a124775fd"), new Guid("5dff9d04-9a72-4cb8-bc73-63ad04078d2d") });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "Body", "ChatId", "IsDelivered", "ReceiverId", "SendAt", "SenderId" },
                values: new object[,]
                {
                    { new Guid("beaeffe3-6f99-4a09-ae08-cd292afd522c"), "Salom", null, true, new Guid("d288a320-adb3-4018-b6ce-449a124775fd"), new DateTimeOffset(new DateTime(2024, 4, 30, 14, 53, 43, 631, DateTimeKind.Unspecified).AddTicks(9792), new TimeSpan(0, 0, 0, 0, 0)), new Guid("5dff9d04-9a72-4cb8-bc73-63ad04078d2d") },
                    { new Guid("c0784785-b0b4-4e6a-9cd0-af47f822c1ee"), "Ishlaring yaxshimi", null, true, new Guid("5dff9d04-9a72-4cb8-bc73-63ad04078d2d"), new DateTimeOffset(new DateTime(2024, 4, 30, 19, 53, 43, 631, DateTimeKind.Unspecified).AddTicks(9838), new TimeSpan(0, 5, 0, 0, 0)), new Guid("d288a320-adb3-4018-b6ce-449a124775fd") }
                });
        }
    }
}
