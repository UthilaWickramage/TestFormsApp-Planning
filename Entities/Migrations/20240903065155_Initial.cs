using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PendingOrders",
                columns: table => new
                {
                    PendingOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PendingOrderTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PendingOrderDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PendingOrderQty = table.Column<int>(type: "int", nullable: false),
                    Client = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpectedDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PendingOrders", x => x.PendingOrderId);
                });

            migrationBuilder.CreateTable(
                name: "WorkStations",
                columns: table => new
                {
                    WorkStationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkStationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CapacityPerHour = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkStations", x => x.WorkStationId);
                });

            migrationBuilder.CreateTable(
                name: "Holiday",
                columns: table => new
                {
                    HolidayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HolidayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HolidayDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkStationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holiday", x => x.HolidayId);
                    table.ForeignKey(
                        name: "FK_Holiday_WorkStations_WorkStationId",
                        column: x => x.WorkStationId,
                        principalTable: "WorkStations",
                        principalColumn: "WorkStationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VisibleStartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VisibleEndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Qty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DurationInHours = table.Column<double>(type: "float", nullable: false),
                    MachineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_WorkStations_MachineId",
                        column: x => x.MachineId,
                        principalTable: "WorkStations",
                        principalColumn: "WorkStationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecialDay",
                columns: table => new
                {
                    SpecialDayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecialDayDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecialDayStartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SpecialDayEndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SpecialDayCapacityPerHour = table.Column<int>(type: "int", nullable: false),
                    WorkStationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialDay", x => x.SpecialDayId);
                    table.ForeignKey(
                        name: "FK_SpecialDay_WorkStations_WorkStationId",
                        column: x => x.WorkStationId,
                        principalTable: "WorkStations",
                        principalColumn: "WorkStationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Holiday_WorkStationId",
                table: "Holiday",
                column: "WorkStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MachineId",
                table: "Orders",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialDay_WorkStationId",
                table: "SpecialDay",
                column: "WorkStationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Holiday");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "PendingOrders");

            migrationBuilder.DropTable(
                name: "SpecialDay");

            migrationBuilder.DropTable(
                name: "WorkStations");
        }
    }
}
