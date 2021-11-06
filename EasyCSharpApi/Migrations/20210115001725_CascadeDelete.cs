using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyCSharpApi.Migrations
{
    public partial class CascadeDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "R_32",
                table: "Progres");

            migrationBuilder.DropForeignKey(
                name: "R_37",
                table: "ProgresItem");

       

            migrationBuilder.AddForeignKey(
                name: "R_32",
                table: "Progres",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "R_37",
                table: "ProgresItem",
                column: "ProgresId",
                principalTable: "Progres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "R_32",
                table: "Progres");

            migrationBuilder.DropForeignKey(
                name: "R_37",
                table: "ProgresItem");

            migrationBuilder.DeleteData(
                table: "Type",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Type",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddForeignKey(
                name: "R_32",
                table: "Progres",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "R_37",
                table: "ProgresItem",
                column: "ProgresId",
                principalTable: "Progres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
