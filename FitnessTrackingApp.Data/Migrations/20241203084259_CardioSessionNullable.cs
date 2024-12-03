using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTrackingApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class CardioSessionNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeeklyPlans_CardioSessions_CardioSessionId",
                table: "WeeklyPlans");

            migrationBuilder.DropIndex(
                name: "IX_GoalPlans_TrainerId_UserId",
                table: "GoalPlans");

            migrationBuilder.DropIndex(
                name: "IX_GoalPlans_UserId",
                table: "GoalPlans");

            migrationBuilder.AlterColumn<long>(
                name: "CardioSessionId",
                table: "WeeklyPlans",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("417ae2a4-ffbb-4e27-855e-d353004e0e91"),
                column: "ConcurrencyStamp",
                value: "0395f523-8ac0-4dc5-9ba9-b2949b409704");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("90162da5-8408-493a-8dae-99995094cf09"),
                column: "ConcurrencyStamp",
                value: "74bd131b-cbdd-4edc-bd76-1abcb4966953");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b0209e85-b41c-472b-a767-037253b72665"),
                column: "ConcurrencyStamp",
                value: "ab162ce4-b9e5-4fd2-87ff-9202dd17a709");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cba94579-9df9-4cda-bf3e-ff5f51048d4b"),
                column: "ConcurrencyStamp",
                value: "704d8ea7-6418-4bc8-8643-e786e0d0762e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e61ce637-3ba1-44a2-8c05-b7c0595c3e5b"),
                column: "ConcurrencyStamp",
                value: "d224a964-446d-491a-ae8e-9cfeee42bab9");

            migrationBuilder.CreateIndex(
                name: "IX_GoalPlans_TrainerId",
                table: "GoalPlans",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_GoalPlans_UserId",
                table: "GoalPlans",
                column: "UserId",
                unique: true,
                filter: "[GoalPlanStatus] = 0");

            migrationBuilder.AddForeignKey(
                name: "FK_WeeklyPlans_CardioSessions_CardioSessionId",
                table: "WeeklyPlans",
                column: "CardioSessionId",
                principalTable: "CardioSessions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeeklyPlans_CardioSessions_CardioSessionId",
                table: "WeeklyPlans");

            migrationBuilder.DropIndex(
                name: "IX_GoalPlans_TrainerId",
                table: "GoalPlans");

            migrationBuilder.DropIndex(
                name: "IX_GoalPlans_UserId",
                table: "GoalPlans");

            migrationBuilder.AlterColumn<long>(
                name: "CardioSessionId",
                table: "WeeklyPlans",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("417ae2a4-ffbb-4e27-855e-d353004e0e91"),
                column: "ConcurrencyStamp",
                value: "99a268ec-2637-4653-b0ad-1dee129c3594");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("90162da5-8408-493a-8dae-99995094cf09"),
                column: "ConcurrencyStamp",
                value: "ef864b11-66f5-4eac-9b1b-742ae6ea59ff");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b0209e85-b41c-472b-a767-037253b72665"),
                column: "ConcurrencyStamp",
                value: "4bc899c3-8a94-4d07-9302-7b13117ae13c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cba94579-9df9-4cda-bf3e-ff5f51048d4b"),
                column: "ConcurrencyStamp",
                value: "9e67a96a-12ff-45be-bd12-2a0fafaabd40");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e61ce637-3ba1-44a2-8c05-b7c0595c3e5b"),
                column: "ConcurrencyStamp",
                value: "22896a7f-3f8e-401a-ad8c-4b1063160e99");

            migrationBuilder.CreateIndex(
                name: "IX_GoalPlans_TrainerId_UserId",
                table: "GoalPlans",
                columns: new[] { "TrainerId", "UserId" },
                unique: true,
                filter: "[GoalPlanStatus] = 1");

            migrationBuilder.CreateIndex(
                name: "IX_GoalPlans_UserId",
                table: "GoalPlans",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeeklyPlans_CardioSessions_CardioSessionId",
                table: "WeeklyPlans",
                column: "CardioSessionId",
                principalTable: "CardioSessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
