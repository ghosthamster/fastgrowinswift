using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyCSharpApi.Migrations
{
    public partial class addedAttemptSequence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AttemtpSequence",
                table: "Answer",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttemtpSequence",
                table: "Answer");
        }
    }
}
