using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTrackingApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class GoalPlanStatusEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GoalPlans_TrainerId_UserId",
                table: "GoalPlans");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "GoalPlans");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "GoalPlans");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "GoalPlans",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "GoalPlanStatus",
                table: "GoalPlans",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GoalPlans_TrainerId_UserId",
                table: "GoalPlans");

            migrationBuilder.DropColumn(
                name: "GoalPlanStatus",
                table: "GoalPlans");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "GoalPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "GoalPlans",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "GoalPlans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("417ae2a4-ffbb-4e27-855e-d353004e0e91"),
                column: "ConcurrencyStamp",
                value: "3e7b760b-318e-4b28-9c3a-1f4d7facac0a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("90162da5-8408-493a-8dae-99995094cf09"),
                column: "ConcurrencyStamp",
                value: "56685257-adf4-4cf7-ae5c-65621f84f975");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b0209e85-b41c-472b-a767-037253b72665"),
                column: "ConcurrencyStamp",
                value: "91d9611d-ba3a-471d-88ab-f36d524e58d8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cba94579-9df9-4cda-bf3e-ff5f51048d4b"),
                column: "ConcurrencyStamp",
                value: "d6eb572b-df69-46c1-ac67-78eb9bbd8ef9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e61ce637-3ba1-44a2-8c05-b7c0595c3e5b"),
                column: "ConcurrencyStamp",
                value: "7a5e7207-5281-4af1-b67a-9ac8917ad5e3");

            migrationBuilder.CreateIndex(
                name: "IX_GoalPlans_TrainerId_UserId",
                table: "GoalPlans",
                columns: new[] { "TrainerId", "UserId" },
                unique: true,
                filter: "[IsActive] = 1");
        }
    }
}
