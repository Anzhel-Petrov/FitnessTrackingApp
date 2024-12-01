using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FitnessTrackingApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedTrainers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("417ae2a4-ffbb-4e27-855e-d353004e0e91"), 0, "3e7b760b-318e-4b28-9c3a-1f4d7facac0a", "trainer@getfit.com", true, false, null, "TRAINER@GETFIT.COM", "TRAINER@GETFIT.COM", "AQAAAAIAAYagAAAAELgDoi5HDG8Pug6HCYSQo6/+SA6L54OY4AGwUyjd0USCYX57uHHIIiuFLC3bJxuafA==", null, false, "4JZZ3RICHGHZ3WDZWHJICS76QRJAESPV", false, "trainer@getfit.com" },
                    { new Guid("90162da5-8408-493a-8dae-99995094cf09"), 0, "56685257-adf4-4cf7-ae5c-65621f84f975", "trainer4@getfit.com", true, false, null, "TRAINER4@GETFIT.COM", "TRAINER4@GETFIT.COM", "AQAAAAIAAYagAAAAED2P7oQH2z6h/CMWDPHngCMirJN+RM3sCXtpmUdMSkRd2HzDYMyxw1Vnu0/ynO1BHA==", null, false, "CPRDG6HRGDF2RZSL25ZQTAQN6CCFN3OU", false, "trainer4@getfit.com" },
                    { new Guid("b0209e85-b41c-472b-a767-037253b72665"), 0, "91d9611d-ba3a-471d-88ab-f36d524e58d8", "trainer5@getfit.com", true, false, null, "TRAINER5@GETFIT.COM", "TRAINER5@GETFIT.COM", "AQAAAAIAAYagAAAAEBlaW8OGa3wuT5fTPou0rvz6TpIbQo8fuiXX64BxjqQDguHMTGANK8dsSA2yotbUig==", null, false, "KLUU7OY42MOI2B6YKLLUTT5KTZX5P4SN", false, "trainer5@getfit.com" },
                    { new Guid("cba94579-9df9-4cda-bf3e-ff5f51048d4b"), 0, "d6eb572b-df69-46c1-ac67-78eb9bbd8ef9", "trainer3@getfit.com", true, false, null, "TRAINER3@GETFIT.COM", "TRAINER3@GETFIT.COM", "AQAAAAIAAYagAAAAEM091clNOAmxwsYSHkdKdFrIX9VqVNOlisCtHCMQsHrCwjO8n3FkR/aTOzjO7U39rA==", null, false, "PS3NQ5SUDKLIPXVZUOLB2WUVYWSCGT4B", false, "trainer3@getfit.com" },
                    { new Guid("e61ce637-3ba1-44a2-8c05-b7c0595c3e5b"), 0, "7a5e7207-5281-4af1-b67a-9ac8917ad5e3", "trainer2@getfit.com", true, false, null, "TRAINER2@GETFIT.COM", "TRAINER2@GETFIT.COM", "AQAAAAIAAYagAAAAEKi4X8jlIeKb2Ks+WTYxDzXEtjWoEEUxXkHQwV4gNQ4Y55lp3v9e73xxGJRC82dC6A==", null, false, "3AYQOQVOUTYD57DGY46IMWFVAQFC7BXE", false, "trainer2@getfit.com" }
                });

            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "Id", "AverageRating", "IsAvailable", "UserId", "YearsOfExperience" },
                values: new object[,]
                {
                    { new Guid("538c0f88-cd08-4dff-9a9e-0b612e436f03"), 0.0, true, new Guid("b0209e85-b41c-472b-a767-037253b72665"), 0 },
                    { new Guid("d6644f7d-214a-4295-a971-7b065bd5c5ac"), 3.8999999999999999, true, new Guid("cba94579-9df9-4cda-bf3e-ff5f51048d4b"), 4 },
                    { new Guid("d8da2c4e-44f5-427d-b6f5-0dccfa1e2a46"), 6.4000000000000004, true, new Guid("417ae2a4-ffbb-4e27-855e-d353004e0e91"), 7 },
                    { new Guid("df3e0b57-1b43-497a-87d0-97a34ba21c92"), 2.2000000000000002, false, new Guid("90162da5-8408-493a-8dae-99995094cf09"), 2 },
                    { new Guid("ec163c02-6fdd-4e66-bec7-a1418a2fe85a"), 8.1999999999999993, true, new Guid("e61ce637-3ba1-44a2-8c05-b7c0595c3e5b"), 12 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: new Guid("538c0f88-cd08-4dff-9a9e-0b612e436f03"));

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: new Guid("d6644f7d-214a-4295-a971-7b065bd5c5ac"));

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: new Guid("d8da2c4e-44f5-427d-b6f5-0dccfa1e2a46"));

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: new Guid("df3e0b57-1b43-497a-87d0-97a34ba21c92"));

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: new Guid("ec163c02-6fdd-4e66-bec7-a1418a2fe85a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("417ae2a4-ffbb-4e27-855e-d353004e0e91"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("90162da5-8408-493a-8dae-99995094cf09"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b0209e85-b41c-472b-a767-037253b72665"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cba94579-9df9-4cda-bf3e-ff5f51048d4b"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e61ce637-3ba1-44a2-8c05-b7c0595c3e5b"));
        }
    }
}
