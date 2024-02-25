using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskBoardApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedEntitiesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BoardId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tasks_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bd411664-87e3-4a28-9bad-66b37e80fda6", 0, "3dd0cc5b-7b46-45f1-8caa-4f4f96ef1e41", null, false, false, null, null, "TEST@SOFTUNI.BG", "AQAAAAIAAYagAAAAEBflGg6k0mBC0rOEFgve6HtaMah/3B4pyYcQYPy+88p9e42LZLMOZOURYxZ6A4Qh2w==", null, false, "4469a467-1160-4b09-83f0-83888e49754d", false, "test@softuni.bg" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "In Progress" },
                    { 3, "Done" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 7, 28, 13, 52, 42, 19, DateTimeKind.Local).AddTicks(5220), "Implement better styling for all public pages", "bd411664-87e3-4a28-9bad-66b37e80fda6", "Improve CSS styles", null },
                    { 2, 1, new DateTime(2023, 9, 13, 13, 52, 42, 19, DateTimeKind.Local).AddTicks(5276), "Create Android client app for the TaskBoard RESTful API", "bd411664-87e3-4a28-9bad-66b37e80fda6", "Android Client App", null },
                    { 3, 2, new DateTime(2024, 1, 13, 13, 52, 42, 19, DateTimeKind.Local).AddTicks(5282), "Create Windows Forms desktop app client for the TaskBoard RESTful API", "bd411664-87e3-4a28-9bad-66b37e80fda6", "Desktop Client App", null },
                    { 4, 3, new DateTime(2023, 2, 13, 13, 52, 42, 19, DateTimeKind.Local).AddTicks(5285), "Implement [Create Task] page for adding new tasks", "bd411664-87e3-4a28-9bad-66b37e80fda6", "Create Tasks", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_BoardId",
                table: "Tasks",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Boards");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bd411664-87e3-4a28-9bad-66b37e80fda6");
        }
    }
}
