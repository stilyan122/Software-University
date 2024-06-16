using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddedAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "PasswordHash", "PhoneNumberConfirmed", "SecurityStamp" },
                values: new object[] { "5c85220a-1a48-43dd-b315-b239d8ace40c", true, "AQAAAAIAAYagAAAAEOUD5IS8pZ+0/UzijTDoKvGahJarRKiWCPvu4cwgDTkWCnaEbrYKGWsb2Fp87YC+Cw==", true, "df28a815-10bd-44f5-a118-57b28817c6e1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "PasswordHash", "PhoneNumberConfirmed", "SecurityStamp" },
                values: new object[] { "ffcde26b-0819-43ee-a2fd-f58d2f269fd7", true, "AQAAAAIAAYagAAAAEA7Kt1afjxTwTH65ReC0jNkeuc8Q4J/rJQK0QXbnm1IzrxFyJuxAb+GKqI1X/C7eaQ==", true, "4a64ddba-d7b1-4ad6-a507-5685882030f1" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bcb4f072-ecca-43c9-ab26-c060c6f364e4", 0, "cc87df3e-f5ea-4449-8b4d-64cb04577235", "admin@gmail.com", false, "Great", "Admin", false, null, "admin@gmail.com", "admin@gmail.com", "AQAAAAIAAYagAAAAEKtIKAyyDq2GuiRqln/DUt6WEHvTTWo3ksvN/FFjBR0QU/GP+ot99lFgVWbcYpKhPQ==", null, false, "1b5296fe-3c1f-46e3-8957-ca5bb96858c8", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 5, "+359123456789", "bcb4f072-ecca-43c9-ab26-c060c6f364e4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "PasswordHash", "PhoneNumberConfirmed", "SecurityStamp" },
                values: new object[] { "11747b9e-c904-42df-992d-29f303c1b132", false, "AQAAAAIAAYagAAAAEPU7waoGSgL4rlaSA5OC1JRYfMKiDRmGMWwVrKaIVIjPlEbsFxoKmnvmELzLvEI2HA==", false, "1fb0c43f-ec30-41cb-b318-80f6c5e43bd7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "PasswordHash", "PhoneNumberConfirmed", "SecurityStamp" },
                values: new object[] { "b06866cc-e045-4e4d-95ad-e7290a5a3d84", false, "AQAAAAIAAYagAAAAECTFXycu29QvrrpQOEXRgqL2ba+xBmsgtJ1QlqtEEpPTCChovwssEr30ZhP5DsRgvA==", false, "ac4caf87-e7a1-47b1-a5a6-805fb1eea027" });
        }
    }
}
