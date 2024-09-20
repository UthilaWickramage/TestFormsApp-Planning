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
            migrationBuilder.DropForeignKey(
                name: "FK_Output_Rate_Operation_Type_OperationTypeId",
                table: "Output_Rate");

            migrationBuilder.DropForeignKey(
                name: "FK_Output_Rate_Products_ProductId",
                table: "Output_Rate");

            migrationBuilder.DropForeignKey(
                name: "FK_Output_Rate_WorkStations_WorkstationId",
                table: "Output_Rate");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleDetails_Operation_Type_OperationTypeId",
                table: "ScheduleDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Output_Rate",
                table: "Output_Rate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Operation_Type",
                table: "Operation_Type");

            migrationBuilder.RenameTable(
                name: "Output_Rate",
                newName: "OutputRates");

            migrationBuilder.RenameTable(
                name: "Operation_Type",
                newName: "OperationTypes");

            migrationBuilder.RenameIndex(
                name: "IX_Output_Rate_WorkstationId",
                table: "OutputRates",
                newName: "IX_OutputRates_WorkstationId");

            migrationBuilder.RenameIndex(
                name: "IX_Output_Rate_ProductId",
                table: "OutputRates",
                newName: "IX_OutputRates_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Output_Rate_OperationTypeId",
                table: "OutputRates",
                newName: "IX_OutputRates_OperationTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OutputRates",
                table: "OutputRates",
                column: "Output_Rate_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OperationTypes",
                table: "OperationTypes",
                column: "Operation_Type_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OutputRates_OperationTypes_OperationTypeId",
                table: "OutputRates",
                column: "OperationTypeId",
                principalTable: "OperationTypes",
                principalColumn: "Operation_Type_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OutputRates_Products_ProductId",
                table: "OutputRates",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Product_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OutputRates_WorkStations_WorkstationId",
                table: "OutputRates",
                column: "WorkstationId",
                principalTable: "WorkStations",
                principalColumn: "WorkStationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleDetails_OperationTypes_OperationTypeId",
                table: "ScheduleDetails",
                column: "OperationTypeId",
                principalTable: "OperationTypes",
                principalColumn: "Operation_Type_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OutputRates_OperationTypes_OperationTypeId",
                table: "OutputRates");

            migrationBuilder.DropForeignKey(
                name: "FK_OutputRates_Products_ProductId",
                table: "OutputRates");

            migrationBuilder.DropForeignKey(
                name: "FK_OutputRates_WorkStations_WorkstationId",
                table: "OutputRates");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleDetails_OperationTypes_OperationTypeId",
                table: "ScheduleDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OutputRates",
                table: "OutputRates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OperationTypes",
                table: "OperationTypes");

            migrationBuilder.RenameTable(
                name: "OutputRates",
                newName: "Output_Rate");

            migrationBuilder.RenameTable(
                name: "OperationTypes",
                newName: "Operation_Type");

            migrationBuilder.RenameIndex(
                name: "IX_OutputRates_WorkstationId",
                table: "Output_Rate",
                newName: "IX_Output_Rate_WorkstationId");

            migrationBuilder.RenameIndex(
                name: "IX_OutputRates_ProductId",
                table: "Output_Rate",
                newName: "IX_Output_Rate_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OutputRates_OperationTypeId",
                table: "Output_Rate",
                newName: "IX_Output_Rate_OperationTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Output_Rate",
                table: "Output_Rate",
                column: "Output_Rate_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Operation_Type",
                table: "Operation_Type",
                column: "Operation_Type_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Output_Rate_Operation_Type_OperationTypeId",
                table: "Output_Rate",
                column: "OperationTypeId",
                principalTable: "Operation_Type",
                principalColumn: "Operation_Type_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Output_Rate_Products_ProductId",
                table: "Output_Rate",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Product_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Output_Rate_WorkStations_WorkstationId",
                table: "Output_Rate",
                column: "WorkstationId",
                principalTable: "WorkStations",
                principalColumn: "WorkStationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleDetails_Operation_Type_OperationTypeId",
                table: "ScheduleDetails",
                column: "OperationTypeId",
                principalTable: "Operation_Type",
                principalColumn: "Operation_Type_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
