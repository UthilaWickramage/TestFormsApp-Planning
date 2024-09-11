using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class Third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Holidays_WorkStations_WorkStationId",
                table: "Holidays");

            migrationBuilder.DropIndex(
                name: "IX_Holidays_WorkStationId",
                table: "Holidays");

            migrationBuilder.DropColumn(
                name: "WorkStationId",
                table: "Holidays");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkStationId",
                table: "Holidays",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Holidays_WorkStationId",
                table: "Holidays",
                column: "WorkStationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Holidays_WorkStations_WorkStationId",
                table: "Holidays",
                column: "WorkStationId",
                principalTable: "WorkStations",
                principalColumn: "WorkStationId");
        }
    }
}
