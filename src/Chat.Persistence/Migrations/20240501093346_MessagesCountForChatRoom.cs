using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Chat.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MessagesCountForChatRoom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: new Guid("7218b486-c370-4339-a506-4bbcd6d60f57"));

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: new Guid("d5032e60-9595-4124-b17f-fb6f32c49be9"));

            migrationBuilder.AddColumn<int>(
                name: "FirstUserUnReadMessageCount",
                table: "ChatRooms",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SecondUserUnReadMessageCount",
                table: "ChatRooms",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "Body", "ChatId", "IsDelivered", "ReceiverId", "SendAt", "SenderId" },
                values: new object[,]
                {
                    { new Guid("32d636d5-64d6-48eb-accd-54b10e43849c"), "Ishlaring yaxshimi", null, true, new Guid("5dff9d04-9a72-4cb8-bc73-63ad04078d2d"), new DateTimeOffset(new DateTime(2024, 5, 1, 14, 33, 46, 81, DateTimeKind.Unspecified).AddTicks(6256), new TimeSpan(0, 5, 0, 0, 0)), new Guid("d288a320-adb3-4018-b6ce-449a124775fd") },
                    { new Guid("e6485974-4157-48a9-838a-e3ecbc31cd74"), "Salom", null, true, new Guid("d288a320-adb3-4018-b6ce-449a124775fd"), new DateTimeOffset(new DateTime(2024, 5, 1, 9, 33, 46, 81, DateTimeKind.Unspecified).AddTicks(6225), new TimeSpan(0, 0, 0, 0, 0)), new Guid("5dff9d04-9a72-4cb8-bc73-63ad04078d2d") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: new Guid("32d636d5-64d6-48eb-accd-54b10e43849c"));

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: new Guid("e6485974-4157-48a9-838a-e3ecbc31cd74"));

            migrationBuilder.DropColumn(
                name: "FirstUserUnReadMessageCount",
                table: "ChatRooms");

            migrationBuilder.DropColumn(
                name: "SecondUserUnReadMessageCount",
                table: "ChatRooms");

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "Body", "ChatId", "IsDelivered", "ReceiverId", "SendAt", "SenderId" },
                values: new object[,]
                {
                    { new Guid("7218b486-c370-4339-a506-4bbcd6d60f57"), "Salom", null, true, new Guid("d288a320-adb3-4018-b6ce-449a124775fd"), new DateTimeOffset(new DateTime(2024, 5, 1, 9, 3, 53, 130, DateTimeKind.Unspecified).AddTicks(7831), new TimeSpan(0, 0, 0, 0, 0)), new Guid("5dff9d04-9a72-4cb8-bc73-63ad04078d2d") },
                    { new Guid("d5032e60-9595-4124-b17f-fb6f32c49be9"), "Ishlaring yaxshimi", null, true, new Guid("5dff9d04-9a72-4cb8-bc73-63ad04078d2d"), new DateTimeOffset(new DateTime(2024, 5, 1, 14, 3, 53, 130, DateTimeKind.Unspecified).AddTicks(7869), new TimeSpan(0, 5, 0, 0, 0)), new Guid("d288a320-adb3-4018-b6ce-449a124775fd") }
                });
        }
    }
}
