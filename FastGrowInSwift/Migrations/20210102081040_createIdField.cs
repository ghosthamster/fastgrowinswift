using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyCSharpApi.Migrations
{
    public partial class createIdField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Title",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Title", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Password = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    DateOfRegister = table.Column<DateTime>(type: "datetime", nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Email = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    DificultyCoef = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    TitleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.Id);
                    table.ForeignKey(
                        name: "R_27",
                        column: x => x.TypeId,
                        principalTable: "Type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "R_28",
                        column: x => x.TitleId,
                        principalTable: "Title",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfAnswer = table.Column<DateTime>(type: "datetime", nullable: true),
                    TimeOfExecution = table.Column<int>(type: "int", nullable: true),
                    CorrectnessPercent = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.Id);
                    table.ForeignKey(
                        name: "R_33",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Progres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SavingDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    TimeOfExecution = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("XPKProgres", x => x.Id);
                    table.ForeignKey(
                        name: "R_32",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User_Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Role", x => x.Id);
                    table.ForeignKey(
                        name: "R_11",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "R_13",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnswerOption_Etalon_",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Order = table.Column<int>(type: "int", nullable: true),
                    TaskId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("XPKAnswerOption_Etalon_", x => x.Id);
                    table.ForeignKey(
                        name: "R_29",
                        column: x => x.TaskId,
                        principalTable: "Task",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnswerItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Order = table.Column<int>(type: "int", nullable: true),
                    CorrectnessPercent = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    AnswerOptionId = table.Column<int>(type: "int", nullable: true),
                    AnswerId = table.Column<int>(type: "int", nullable: false),
                    TaskId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerItem", x => x.Id);
                    table.ForeignKey(
                        name: "R_30",
                        column: x => x.AnswerOptionId,
                        principalTable: "AnswerOption_Etalon_",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "R_31",
                        column: x => x.AnswerId,
                        principalTable: "Answer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "R_35",
                        column: x => x.TaskId,
                        principalTable: "Task",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProgresItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Order = table.Column<int>(type: "int", nullable: true),
                    TaskId = table.Column<int>(type: "int", nullable: true),
                    ProgresId = table.Column<int>(type: "int", nullable: false),
                    AnswerOptionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgresItem", x => x.Id);
                    table.ForeignKey(
                        name: "R_36",
                        column: x => x.TaskId,
                        principalTable: "Task",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "R_37",
                        column: x => x.ProgresId,
                        principalTable: "Progres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "R_39",
                        column: x => x.AnswerOptionId,
                        principalTable: "AnswerOption_Etalon_",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answer_UserId",
                table: "Answer",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerItem_AnswerId",
                table: "AnswerItem",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerItem_AnswerOptionId",
                table: "AnswerItem",
                column: "AnswerOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerItem_TaskId",
                table: "AnswerItem",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerOption_Etalon__TaskId",
                table: "AnswerOption_Etalon_",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Progres_UserId",
                table: "Progres",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgresItem_AnswerOptionId",
                table: "ProgresItem",
                column: "AnswerOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgresItem_ProgresId",
                table: "ProgresItem",
                column: "ProgresId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgresItem_TaskId",
                table: "ProgresItem",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_TitleId",
                table: "Task",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_TypeId",
                table: "Task",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Role_RoleId",
                table: "User_Role",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Role_UserId",
                table: "User_Role",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswerItem");

            migrationBuilder.DropTable(
                name: "ProgresItem");

            migrationBuilder.DropTable(
                name: "User_Role");

            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropTable(
                name: "Progres");

            migrationBuilder.DropTable(
                name: "AnswerOption_Etalon_");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "Type");

            migrationBuilder.DropTable(
                name: "Title");
        }
    }
}
