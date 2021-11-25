using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyCSharpApi.Migrations
{
    public partial class addedTaskId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "R_35",
                table: "AnswerItem");

            migrationBuilder.DropIndex(
                name: "IX_AnswerItem_TaskId",
                table: "AnswerItem");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "AnswerItem");

            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "Answer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Answer_TaskId",
                table: "Answer",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "task_answer",
                table: "Answer",
                column: "TaskId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "task_answer",
                table: "Answer");

            migrationBuilder.DropIndex(
                name: "IX_Answer_TaskId",
                table: "Answer");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "Answer");

            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "AnswerItem",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnswerItem_TaskId",
                table: "AnswerItem",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "R_35",
                table: "AnswerItem",
                column: "TaskId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
