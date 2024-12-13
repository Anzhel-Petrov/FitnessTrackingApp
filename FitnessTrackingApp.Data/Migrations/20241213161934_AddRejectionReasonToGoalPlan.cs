using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTrackingApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRejectionReasonToGoalPlan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RejectionReason",
                table: "GoalPlans",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RejectionReason",
                table: "GoalPlans");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("417ae2a4-ffbb-4e27-855e-d353004e0e91"),
                column: "ConcurrencyStamp",
                value: "e3e7396b-ccb4-4deb-b3af-d41ec4471c4b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("90162da5-8408-493a-8dae-99995094cf09"),
                column: "ConcurrencyStamp",
                value: "e64a1432-d40a-48ad-91fa-45f9002739bb");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b0209e85-b41c-472b-a767-037253b72665"),
                column: "ConcurrencyStamp",
                value: "877e7110-25c1-4335-94f1-1b131a75b3f1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cba94579-9df9-4cda-bf3e-ff5f51048d4b"),
                column: "ConcurrencyStamp",
                value: "dc0502b9-25f1-4176-a142-5bbf830d3e9e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e61ce637-3ba1-44a2-8c05-b7c0595c3e5b"),
                column: "ConcurrencyStamp",
                value: "46f8f979-5b95-4120-a15d-2918f434a84f");
        }
    }
}
