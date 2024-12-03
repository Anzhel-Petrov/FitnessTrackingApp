using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTrackingApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeBodyWeightLogRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BodyWeightLogs_AspNetUsers_UserId",
                table: "BodyWeightLogs");

            migrationBuilder.DropIndex(
                name: "IX_BodyWeightLogs_DateLogged_UserId",
                table: "BodyWeightLogs");

            migrationBuilder.DropIndex(
                name: "IX_BodyWeightLogs_UserId",
                table: "BodyWeightLogs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BodyWeightLogs");

            migrationBuilder.AddColumn<long>(
                name: "GoalPlanId",
                table: "BodyWeightLogs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

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

            migrationBuilder.CreateIndex(
                name: "IX_BodyWeightLogs_DateLogged_GoalPlanId",
                table: "BodyWeightLogs",
                columns: new[] { "DateLogged", "GoalPlanId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BodyWeightLogs_GoalPlanId",
                table: "BodyWeightLogs",
                column: "GoalPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_BodyWeightLogs_GoalPlans_GoalPlanId",
                table: "BodyWeightLogs",
                column: "GoalPlanId",
                principalTable: "GoalPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BodyWeightLogs_GoalPlans_GoalPlanId",
                table: "BodyWeightLogs");

            migrationBuilder.DropIndex(
                name: "IX_BodyWeightLogs_DateLogged_GoalPlanId",
                table: "BodyWeightLogs");

            migrationBuilder.DropIndex(
                name: "IX_BodyWeightLogs_GoalPlanId",
                table: "BodyWeightLogs");

            migrationBuilder.DropColumn(
                name: "GoalPlanId",
                table: "BodyWeightLogs");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "BodyWeightLogs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
                name: "IX_BodyWeightLogs_DateLogged_UserId",
                table: "BodyWeightLogs",
                columns: new[] { "DateLogged", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BodyWeightLogs_UserId",
                table: "BodyWeightLogs",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BodyWeightLogs_AspNetUsers_UserId",
                table: "BodyWeightLogs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
