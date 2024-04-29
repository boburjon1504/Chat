using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Chat.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedChat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_ChatRooms_ChatId",
                table: "Messages");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("33c7eab9-ecf0-4a2e-b8c1-c4e53410ebe1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("36d93ea5-26a9-42b0-9383-3a2c78dceee2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4f44febc-93c8-4161-ac19-3a7b1695fc61"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("555dc4ff-dac8-4a6c-9088-0e93b95a752b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("61fd9b7f-4658-41c2-9ddb-a566d220714e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("62070666-dbd7-4628-9f81-25076a1e483f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9709d8cf-24f4-4958-89de-cebccc844706"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a2fc1cea-6409-4861-88cc-a317522a7ae2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c00ee1f8-ecbe-4bfd-b6aa-a94efc63924b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f07b14c1-6ab2-499d-aa80-8b971a85daf6"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ChatId",
                table: "Messages",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "Body", "ChatId", "IsDelivered", "ReceiverId", "SendAt", "SenderId" },
                values: new object[,]
                {
                    { new Guid("2633573d-e18d-4726-8b87-46a0d3b8b188"), "Ishlaring yaxshimi", null, true, new Guid("5dff9d04-9a72-4cb8-bc73-63ad04078d2d"), new DateTimeOffset(new DateTime(2024, 4, 30, 0, 31, 23, 601, DateTimeKind.Unspecified).AddTicks(9317), new TimeSpan(0, 5, 0, 0, 0)), new Guid("d288a320-adb3-4018-b6ce-449a124775fd") },
                    { new Guid("8ee8d6f9-2ba4-446c-998d-368b33354f05"), "Salom", null, true, new Guid("d288a320-adb3-4018-b6ce-449a124775fd"), new DateTimeOffset(new DateTime(2024, 4, 29, 19, 31, 23, 601, DateTimeKind.Unspecified).AddTicks(9274), new TimeSpan(0, 0, 0, 0, 0)), new Guid("5dff9d04-9a72-4cb8-bc73-63ad04078d2d") }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_ChatRooms_ChatId",
                table: "Messages",
                column: "ChatId",
                principalTable: "ChatRooms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_ChatRooms_ChatId",
                table: "Messages");

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: new Guid("2633573d-e18d-4726-8b87-46a0d3b8b188"));

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: new Guid("8ee8d6f9-2ba4-446c-998d-368b33354f05"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ChatId",
                table: "Messages",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "IsOnline", "LastName", "Password", "UserName" },
                values: new object[,]
                {
                    { new Guid("33c7eab9-ecf0-4a2e-b8c1-c4e53410ebe1"), "jennifer.davis@email.com", "Jennifer", false, "Davis", "password", "jenniferd92" },
                    { new Guid("36d93ea5-26a9-42b0-9383-3a2c78dceee2"), "sarah.garcia@email.com", "Sarah", false, "Garcia", "password", "sg_2001" },
                    { new Guid("4f44febc-93c8-4161-ac19-3a7b1695fc61"), "emily.jones@email.com", "Emily", false, "Jones", "password", "emilyj2023" },
                    { new Guid("555dc4ff-dac8-4a6c-9088-0e93b95a752b"), "william.miller@email.com", "William", false, "Miller", "password", "wmiller10" },
                    { new Guid("61fd9b7f-4658-41c2-9ddb-a566d220714e"), "david.lee@email.com", "David", false, "Lee", "password", "davidlee99" },
                    { new Guid("62070666-dbd7-4628-9f81-25076a1e483f"), "alice.smith@email.com", "Alice", false, "Smith", "password", "alicesmith87" },
                    { new Guid("9709d8cf-24f4-4958-89de-cebccc844706"), "matthew.hernandez@email.com", "Matthew", false, "Hernandez", "password", "mherndz88" },
                    { new Guid("a2fc1cea-6409-4861-88cc-a317522a7ae2"), "ashley.young@email.com", "Ashley", false, "Young", "password", "ash_young95" },
                    { new Guid("c00ee1f8-ecbe-4bfd-b6aa-a94efc63924b"), "michael.brown@email.com", "Michael", false, "Brown", "password", "mikebrown7" },
                    { new Guid("f07b14c1-6ab2-499d-aa80-8b971a85daf6"), "jane.doe@email.com", "John", false, "Doe", "password", "johndoe123" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_ChatRooms_ChatId",
                table: "Messages",
                column: "ChatId",
                principalTable: "ChatRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
