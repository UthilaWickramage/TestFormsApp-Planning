using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ScheduleDetails_OrderId",
                table: "ScheduleDetails");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleDetails_OrderId",
                table: "ScheduleDetails",
                column: "OrderId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ScheduleDetails_OrderId",
                table: "ScheduleDetails");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleDetails_OrderId",
                table: "ScheduleDetails",
                column: "OrderId");
        }
    }
}
