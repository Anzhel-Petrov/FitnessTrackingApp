using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTrackingApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class RefBodyWeightLogToWeeklyPlan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BodyWeightLogs_GoalPlans_GoalPlanId",
                table: "BodyWeightLogs");

            migrationBuilder.RenameColumn(
                name: "GoalPlanId",
                table: "BodyWeightLogs",
                newName: "WeeklyPlanId");

            migrationBuilder.RenameIndex(
                name: "IX_BodyWeightLogs_GoalPlanId",
                table: "BodyWeightLogs",
                newName: "IX_BodyWeightLogs_WeeklyPlanId");

            migrationBuilder.RenameIndex(
                name: "IX_BodyWeightLogs_DateLogged_GoalPlanId",
                table: "BodyWeightLogs",
                newName: "IX_BodyWeightLogs_DateLogged_WeeklyPlanId");

            migrationBuilder.AddColumn<decimal>(
                name: "CurrentWeight",
                table: "GoalPlans",
                type: "decimal(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "GoalWeigh",
                table: "GoalPlans",
                type: "decimal(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("417ae2a4-ffbb-4e27-855e-d353004e0e91"),
                column: "ConcurrencyStamp",
                value: "1805cab5-04ab-46e0-a5b8-46fba2628697");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("90162da5-8408-493a-8dae-99995094cf09"),
                column: "ConcurrencyStamp",
                value: "982c2bb3-35b5-4bfb-ba3b-d450cf484dc2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b0209e85-b41c-472b-a767-037253b72665"),
                column: "ConcurrencyStamp",
                value: "7cc89a22-e709-4767-b00d-8c1bfb08735e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cba94579-9df9-4cda-bf3e-ff5f51048d4b"),
                column: "ConcurrencyStamp",
                value: "3c4d6b5c-1c5e-4642-ac30-0ece9c2bd44c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e61ce637-3ba1-44a2-8c05-b7c0595c3e5b"),
                column: "ConcurrencyStamp",
                value: "2cb16ada-56cc-42af-ba06-550eabbd1209");

            migrationBuilder.AddForeignKey(
                name: "FK_BodyWeightLogs_WeeklyPlans_WeeklyPlanId",
                table: "BodyWeightLogs",
                column: "WeeklyPlanId",
                principalTable: "WeeklyPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BodyWeightLogs_WeeklyPlans_WeeklyPlanId",
                table: "BodyWeightLogs");

            migrationBuilder.DropColumn(
                name: "CurrentWeight",
                table: "GoalPlans");

            migrationBuilder.DropColumn(
                name: "GoalWeigh",
                table: "GoalPlans");

            migrationBuilder.RenameColumn(
                name: "WeeklyPlanId",
                table: "BodyWeightLogs",
                newName: "GoalPlanId");

            migrationBuilder.RenameIndex(
                name: "IX_BodyWeightLogs_WeeklyPlanId",
                table: "BodyWeightLogs",
                newName: "IX_BodyWeightLogs_GoalPlanId");

            migrationBuilder.RenameIndex(
                name: "IX_BodyWeightLogs_DateLogged_WeeklyPlanId",
                table: "BodyWeightLogs",
                newName: "IX_BodyWeightLogs_DateLogged_GoalPlanId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("417ae2a4-ffbb-4e27-855e-d353004e0e91"),
                column: "ConcurrencyStamp",
                value: "8a5c5500-5a7f-4fe6-ad9d-4020ea23bd05");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("90162da5-8408-493a-8dae-99995094cf09"),
                column: "ConcurrencyStamp",
                value: "ed12bf6e-ba32-41f6-ad1d-1c2d3b958c22");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b0209e85-b41c-472b-a767-037253b72665"),
                column: "ConcurrencyStamp",
                value: "de31f7c4-592c-468c-a049-79ab7e2a49b8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cba94579-9df9-4cda-bf3e-ff5f51048d4b"),
                column: "ConcurrencyStamp",
                value: "d9d3bf00-1791-4c41-995f-bba88e600f7a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e61ce637-3ba1-44a2-8c05-b7c0595c3e5b"),
                column: "ConcurrencyStamp",
                value: "9181f9d8-94b8-4afe-a1c1-5d69b4267192");

            migrationBuilder.AddForeignKey(
                name: "FK_BodyWeightLogs_GoalPlans_GoalPlanId",
                table: "BodyWeightLogs",
                column: "GoalPlanId",
                principalTable: "GoalPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
