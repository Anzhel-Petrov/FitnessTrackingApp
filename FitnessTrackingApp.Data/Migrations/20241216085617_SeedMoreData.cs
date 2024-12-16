using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FitnessTrackingApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedMoreData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "GoalType",
                table: "GoalPlans",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("417ae2a4-ffbb-4e27-855e-d353004e0e91"),
                column: "ConcurrencyStamp",
                value: "08731c6b-c7f8-422d-8575-10feff237a8d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("90162da5-8408-493a-8dae-99995094cf09"),
                column: "ConcurrencyStamp",
                value: "2fc9b122-3787-4678-9841-92405044c777");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b0209e85-b41c-472b-a767-037253b72665"),
                column: "ConcurrencyStamp",
                value: "30367b48-f48a-4edc-8fa2-482071804c31");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cba94579-9df9-4cda-bf3e-ff5f51048d4b"),
                column: "ConcurrencyStamp",
                value: "9c44f5cb-e829-403f-a01c-5b2eb2e06937");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e61ce637-3ba1-44a2-8c05-b7c0595c3e5b"),
                column: "ConcurrencyStamp",
                value: "ca667a3a-0c53-4922-b4f8-404d70119449");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("93a51770-ad3d-4d2c-8ec9-87d500d1b713"), 0, "593c365a-61ee-4058-91f8-179e9f7d5d0b", "admin@getfit.com", true, false, null, "ADMIN@GETFIT.COM", "ADMIN@GETFIT.COM", "AQAAAAIAAYagAAAAEBC45dsFm0ECylQOM9W7nso0B7mQTTQnZyY1ZPiVZkLCj8f2pn7zHAutjf30zz4duA==", null, false, "KWLDFGGAHH2FVG4LKU6VYF6DTO5HF6XQ", false, "admin@getfit.com" },
                    { new Guid("998cd43d-18c0-45a1-8945-ad10a045879c"), 0, "920c2758-10af-472c-bf21-b4ff5692eb81", "customer@getfit.com", true, false, null, "CUSTOMER@GETFIT.COM", "CUSTOMER@GETFIT.COM", "AQAAAAIAAYagAAAAEEGajbY5tkobSYD+nF2Gg7/r5/1jfdmmZ9EwiLi8CuuoEBPjTLnUK4NKkgukS1WMug==", null, false, "XSQNL6UP4MS75TOZ6ZSUU2KWLYQ544CH", false, "customer@getfit.com" }
                });

            migrationBuilder.InsertData(
                table: "CardioSessions",
                columns: new[] { "Id", "Calories", "IsHIIT", "SessionsPerWeek" },
                values: new object[,]
                {
                    { 1L, 300, false, 1 },
                    { 2L, 300, false, 2 },
                    { 3L, 300, false, 2 },
                    { 4L, 300, false, 3 },
                    { 5L, 300, false, 3 },
                    { 6L, 300, false, 3 },
                    { 7L, 300, false, 4 },
                    { 8L, 300, false, 4 },
                    { 9L, 300, true, 4 },
                    { 10L, 300, true, 4 }
                });

            migrationBuilder.InsertData(
                table: "Macros",
                columns: new[] { "Id", "DailyCarbohydrates", "DailyFat", "DailyProtein" },
                values: new object[,]
                {
                    { 1L, 225, 55, 190 },
                    { 2L, 250, 55, 190 },
                    { 3L, 250, 55, 190 },
                    { 4L, 250, 55, 190 },
                    { 5L, 250, 55, 190 },
                    { 6L, 250, 55, 190 },
                    { 7L, 250, 55, 190 },
                    { 8L, 225, 50, 180 },
                    { 9L, 225, 50, 180 },
                    { 10L, 225, 50, 180 }
                });

            migrationBuilder.InsertData(
                table: "GoalPlans",
                columns: new[] { "Id", "CurrentWeight", "EndDate", "GoalPlanStatus", "GoalType", "GoalWeigh", "RejectionReason", "StartDate", "TrainerId", "UserId" },
                values: new object[,]
                {
                    { 1L, 93m, new DateTime(2025, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0, 78m, null, new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d8da2c4e-44f5-427d-b6f5-0dccfa1e2a46"), new Guid("998cd43d-18c0-45a1-8945-ad10a045879c") },
                    { 2L, 102m, new DateTime(2024, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 0, 90m, null, new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d8da2c4e-44f5-427d-b6f5-0dccfa1e2a46"), new Guid("998cd43d-18c0-45a1-8945-ad10a045879c") },
                    { 3L, 113m, new DateTime(2024, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 0, 100m, null, new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d8da2c4e-44f5-427d-b6f5-0dccfa1e2a46"), new Guid("998cd43d-18c0-45a1-8945-ad10a045879c") },
                    { 4L, 123m, new DateTime(2024, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0, 78m, "The desired weight loss for that period is not achievable. Let's do something realistic.", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d8da2c4e-44f5-427d-b6f5-0dccfa1e2a46"), new Guid("998cd43d-18c0-45a1-8945-ad10a045879c") },
                    { 5L, 123m, new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 0, 110m, null, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d8da2c4e-44f5-427d-b6f5-0dccfa1e2a46"), new Guid("998cd43d-18c0-45a1-8945-ad10a045879c") },
                    { 6L, 132m, new DateTime(2024, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 0, 124m, null, new DateTime(2024, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d8da2c4e-44f5-427d-b6f5-0dccfa1e2a46"), new Guid("998cd43d-18c0-45a1-8945-ad10a045879c") }
                });

            migrationBuilder.InsertData(
                table: "CustomerDetails",
                columns: new[] { "Id", "AdditionalNotes", "DateCreated", "GoalPlanId", "GoalType", "StartingWeight", "TargetWeight" },
                values: new object[,]
                {
                    { 1L, "I am back for more - more motivated than ever to get leaner and stronger.", new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 0, 93m, 78m },
                    { 2L, "The last session was great, but I think I am able to cut down more and get in better shape.", new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, 0, 102m, 90m },
                    { 3L, "Having hypothyroidism I started to realize I was gaining weight easier than before and not the good kind of weight wither. With the help of Matt the focus was to stay active, hit my macros on a daily basis and the change will come. I wasn't perfect but I was able to go down in weight and was able to fit on my old clothes that haven't been able to wear in 2 years. Staying consistent, active and still eating the things I love, made it very enjoyable for me. I am extremely happy of my progress and have re-found my confidence I was missing.", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3L, 0, 113m, 110m },
                    { 4L, "I need to loose some weight. I have a condition called hypothyroidism and over the past years I gained a lot of weight. I am ready to do whatever it takes to loose that weight fast!", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L, 0, 123m, 78m },
                    { 5L, "", new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5L, 0, 123m, 110m },
                    { 6L, "", new DateTime(2024, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 6L, 0, 132m, 124m }
                });

            migrationBuilder.InsertData(
                table: "WeeklyPlans",
                columns: new[] { "Id", "CardioSessionId", "EndDate", "GoalPlanId", "MacroId", "StartDate", "Week" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 1L, new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2L, 2L, new DateTime(2024, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 2L, new DateTime(2024, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3L, 3L, new DateTime(2024, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 3L, new DateTime(2024, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4L, 4L, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 4L, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 5L, 5L, new DateTime(2025, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 5L, new DateTime(2025, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 6L, 6L, new DateTime(2025, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 6L, new DateTime(2025, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 7L, 7L, new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 7L, new DateTime(2025, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 8L, 8L, new DateTime(2025, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 8L, new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 9L, 9L, new DateTime(2025, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 9L, new DateTime(2025, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 10L, 10L, new DateTime(2025, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 10L, new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 }
                });

            migrationBuilder.InsertData(
                table: "BodyWeightLogs",
                columns: new[] { "Id", "CurrentWeight", "DateLogged", "WeeklyPlanId" },
                values: new object[,]
                {
                    { 1L, 93.4m, new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L },
                    { 2L, 93.2m, new DateTime(2024, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L },
                    { 3L, 93m, new DateTime(2024, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L },
                    { 4L, 92.8m, new DateTime(2024, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L },
                    { 5L, 92.6m, new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L },
                    { 6L, 92.4m, new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L },
                    { 7L, 92.1m, new DateTime(2024, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L },
                    { 8L, 91.7m, new DateTime(2024, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L },
                    { 9L, 91.4m, new DateTime(2024, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L },
                    { 10L, 91.4m, new DateTime(2024, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L },
                    { 11L, 91.1m, new DateTime(2024, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L },
                    { 12L, 89.7m, new DateTime(2024, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L },
                    { 13L, 89.7m, new DateTime(2024, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L },
                    { 14L, 89.6m, new DateTime(2024, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L },
                    { 15L, 89.5m, new DateTime(2024, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L },
                    { 16L, 90m, new DateTime(2024, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L },
                    { 17L, 89.8m, new DateTime(2024, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3L },
                    { 18L, 89.8m, new DateTime(2024, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 3L },
                    { 19L, 89.6m, new DateTime(2024, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 3L },
                    { 20L, 89.5m, new DateTime(2024, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3L },
                    { 21L, 89.4m, new DateTime(2024, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 3L },
                    { 22L, 89.3m, new DateTime(2024, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3L },
                    { 23L, 89.4m, new DateTime(2024, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 3L },
                    { 24L, 89.4m, new DateTime(2024, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3L },
                    { 25L, 89.2m, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L },
                    { 26L, 89m, new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L },
                    { 27L, 89m, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L },
                    { 28L, 88.8m, new DateTime(2025, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L },
                    { 29L, 88.8m, new DateTime(2025, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L },
                    { 30L, 88.6m, new DateTime(2025, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L },
                    { 31L, 88.5m, new DateTime(2025, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L },
                    { 32L, 88.4m, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L },
                    { 33L, 88.4m, new DateTime(2025, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 5L },
                    { 34L, 88.2m, new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5L },
                    { 35L, 88.2m, new DateTime(2025, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 5L },
                    { 36L, 88m, new DateTime(2025, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 5L },
                    { 37L, 88m, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5L },
                    { 38L, 87.9m, new DateTime(2025, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 5L },
                    { 39L, 87.8m, new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 5L },
                    { 40L, 87.5m, new DateTime(2025, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 5L },
                    { 41L, 87.3m, new DateTime(2025, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 6L },
                    { 42L, 87.1m, new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 6L },
                    { 43L, 87.1m, new DateTime(2025, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 6L },
                    { 44L, 87m, new DateTime(2025, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 6L },
                    { 45L, 86.6m, new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 6L },
                    { 46L, 86.8m, new DateTime(2025, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 6L },
                    { 47L, 86.7m, new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 6L },
                    { 48L, 86.5m, new DateTime(2025, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 6L },
                    { 49L, 86.3m, new DateTime(2025, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 7L },
                    { 50L, 86.1m, new DateTime(2025, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 7L },
                    { 51L, 86m, new DateTime(2025, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 7L },
                    { 52L, 86m, new DateTime(2025, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 7L },
                    { 53L, 85.8m, new DateTime(2025, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 7L },
                    { 54L, 85.7m, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7L },
                    { 55L, 85.6m, new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 7L },
                    { 56L, 85.5m, new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 7L },
                    { 57L, 85.3m, new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 8L },
                    { 58L, 85.7m, new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 8L },
                    { 59L, 85.1m, new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 8L },
                    { 60L, 85m, new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 8L },
                    { 61L, 84.8m, new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 8L },
                    { 62L, 84.8m, new DateTime(2025, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 8L },
                    { 63L, 84.8m, new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 8L },
                    { 64L, 84.7m, new DateTime(2025, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 8L },
                    { 65L, 84.7m, new DateTime(2025, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 9L },
                    { 66L, 84.7m, new DateTime(2025, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 9L },
                    { 67L, 84.7m, new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 9L },
                    { 68L, 84.4m, new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 9L },
                    { 69L, 84.2m, new DateTime(2025, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 9L },
                    { 70L, 84.2m, new DateTime(2025, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 9L },
                    { 71L, 84m, new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 9L },
                    { 72L, 83.8m, new DateTime(2025, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 9L },
                    { 73L, 83.7m, new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 10L },
                    { 74L, 83.7m, new DateTime(2025, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 10L },
                    { 75L, 83.6m, new DateTime(2025, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 10L },
                    { 76L, 83.8m, new DateTime(2025, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 10L },
                    { 77L, 83.4m, new DateTime(2025, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 10L },
                    { 78L, 83.4m, new DateTime(2025, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 10L },
                    { 79L, 83.3m, new DateTime(2025, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 10L },
                    { 80L, 83m, new DateTime(2025, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 10L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("93a51770-ad3d-4d2c-8ec9-87d500d1b713"));

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 24L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 25L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 26L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 27L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 28L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 29L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 30L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 31L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 32L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 33L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 34L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 35L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 36L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 37L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 38L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 39L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 40L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 41L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 42L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 43L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 44L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 45L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 46L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 47L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 48L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 49L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 50L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 51L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 52L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 53L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 54L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 55L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 56L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 57L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 58L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 59L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 60L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 61L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 62L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 63L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 64L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 65L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 66L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 67L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 68L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 69L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 70L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 71L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 72L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 73L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 74L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 75L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 76L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 77L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 78L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 79L);

            migrationBuilder.DeleteData(
                table: "BodyWeightLogs",
                keyColumn: "Id",
                keyValue: 80L);

            migrationBuilder.DeleteData(
                table: "CustomerDetails",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "CustomerDetails",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "CustomerDetails",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "CustomerDetails",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "CustomerDetails",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "CustomerDetails",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "GoalPlans",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "GoalPlans",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "GoalPlans",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "GoalPlans",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "GoalPlans",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "WeeklyPlans",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "WeeklyPlans",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "WeeklyPlans",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "WeeklyPlans",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "WeeklyPlans",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "WeeklyPlans",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "WeeklyPlans",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "WeeklyPlans",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "WeeklyPlans",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "WeeklyPlans",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "CardioSessions",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "CardioSessions",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "CardioSessions",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "CardioSessions",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "CardioSessions",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "CardioSessions",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "CardioSessions",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "CardioSessions",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "CardioSessions",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "CardioSessions",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "GoalPlans",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Macros",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Macros",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Macros",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Macros",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Macros",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Macros",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Macros",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Macros",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Macros",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Macros",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("998cd43d-18c0-45a1-8945-ad10a045879c"));

            migrationBuilder.AlterColumn<int>(
                name: "GoalType",
                table: "GoalPlans",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("417ae2a4-ffbb-4e27-855e-d353004e0e91"),
                column: "ConcurrencyStamp",
                value: "b3071336-a968-475a-bb0b-20e5f7101fc1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("90162da5-8408-493a-8dae-99995094cf09"),
                column: "ConcurrencyStamp",
                value: "211ecc76-9990-4edd-b3e4-b73fc8dac467");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b0209e85-b41c-472b-a767-037253b72665"),
                column: "ConcurrencyStamp",
                value: "1791d992-0f84-4dbb-bdcf-a60ba92d6de5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cba94579-9df9-4cda-bf3e-ff5f51048d4b"),
                column: "ConcurrencyStamp",
                value: "c267467b-ad4a-4ada-a18f-c40b8254c077");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e61ce637-3ba1-44a2-8c05-b7c0595c3e5b"),
                column: "ConcurrencyStamp",
                value: "4cd6c4b4-c167-4e1f-b43e-6ba9efec0c20");
        }
    }
}
