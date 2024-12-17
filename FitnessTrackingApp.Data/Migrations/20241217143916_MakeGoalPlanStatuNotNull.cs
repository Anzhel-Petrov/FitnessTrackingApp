using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTrackingApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class MakeGoalPlanStatuNotNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                value: "98c74516-4b39-4766-ab54-3ab023c80545");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("90162da5-8408-493a-8dae-99995094cf09"),
                column: "ConcurrencyStamp",
                value: "2564023e-9496-46cf-9085-07d8ab1bbacc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("93a51770-ad3d-4d2c-8ec9-87d500d1b713"),
                column: "ConcurrencyStamp",
                value: "c035152b-b55f-403d-ba3e-70b339c68f23");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("998cd43d-18c0-45a1-8945-ad10a045879c"),
                column: "ConcurrencyStamp",
                value: "662e72ea-c981-435d-8945-a51634600ac2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b0209e85-b41c-472b-a767-037253b72665"),
                column: "ConcurrencyStamp",
                value: "c2c69c7c-654c-4b4a-bf71-e058e50e9b83");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cba94579-9df9-4cda-bf3e-ff5f51048d4b"),
                column: "ConcurrencyStamp",
                value: "c775ffd6-41f9-4a03-a3d1-b6202771b3bd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e61ce637-3ba1-44a2-8c05-b7c0595c3e5b"),
                column: "ConcurrencyStamp",
                value: "7543529c-09f9-40c0-bb37-2b954bdaa8e9");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: new Guid("93a51770-ad3d-4d2c-8ec9-87d500d1b713"),
                column: "ConcurrencyStamp",
                value: "593c365a-61ee-4058-91f8-179e9f7d5d0b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("998cd43d-18c0-45a1-8945-ad10a045879c"),
                column: "ConcurrencyStamp",
                value: "920c2758-10af-472c-bf21-b4ff5692eb81");

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
        }
    }
}
