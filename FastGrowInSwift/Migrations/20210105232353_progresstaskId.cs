using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyCSharpApi.Migrations
{
    public partial class progresstaskId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "R_36",
                table: "ProgresItem");

            migrationBuilder.DropIndex(
                name: "IX_ProgresItem_TaskId",
                table: "ProgresItem");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "ProgresItem");

            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "Progres",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Progres_TaskId",
                table: "Progres",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "R_36",
                table: "Progres",
                column: "TaskId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "R_36",
                table: "Progres");

            migrationBuilder.DropIndex(
                name: "IX_Progres_TaskId",
                table: "Progres");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "Progres");

            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "ProgresItem",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProgresItem_TaskId",
                table: "ProgresItem",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "R_36",
                table: "ProgresItem",
                column: "TaskId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
