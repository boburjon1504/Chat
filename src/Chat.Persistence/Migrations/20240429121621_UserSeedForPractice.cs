using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Chat.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UserSeedForPractice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
