using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTrackingApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BodyWeightLogs_DateLogged",
                table: "BodyWeightLogs");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "GoalPlans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CustomerDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoalPlanId = table.Column<long>(type: "bigint", nullable: false),
                    GoalDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AdditionalNotes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    StartingWeight = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    TargetWeight = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerDetails_GoalPlans_GoalPlanId",
                        column: x => x.GoalPlanId,
                        principalTable: "GoalPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BodyWeightLogs_DateLogged_UserId",
                table: "BodyWeightLogs",
                columns: new[] { "DateLogged", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerDetails_GoalPlanId",
                table: "CustomerDetails",
                column: "GoalPlanId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerDetails");

            migrationBuilder.DropIndex(
                name: "IX_BodyWeightLogs_DateLogged_UserId",
                table: "BodyWeightLogs");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "GoalPlans");

            migrationBuilder.CreateIndex(
                name: "IX_BodyWeightLogs_DateLogged",
                table: "BodyWeightLogs",
                column: "DateLogged",
                unique: true);
        }
    }
}
