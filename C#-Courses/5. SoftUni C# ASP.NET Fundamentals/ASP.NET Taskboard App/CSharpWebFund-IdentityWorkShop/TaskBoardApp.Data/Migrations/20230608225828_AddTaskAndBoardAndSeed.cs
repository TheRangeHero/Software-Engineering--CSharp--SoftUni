using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class AddTaskAndBoardAndSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BoardId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Open" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "In Progress" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Done Board" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { new Guid("7e61dfbf-c2a5-43dc-827c-c60ac63d6f8f"), 2, new DateTime(2023, 5, 8, 22, 58, 28, 682, DateTimeKind.Utc).AddTicks(6362), "Create Desktop client App for the Restfull TaskBoard Service", "4192ab0d-b447-4cbe-8ec9-355ec9dfa86d", "Desktop Client App" },
                    { new Guid("889edaf3-1a8b-41cf-b0f0-e81c413b0d75"), 3, new DateTime(2023, 5, 8, 22, 58, 28, 682, DateTimeKind.Utc).AddTicks(6363), "Implement [Create Task] page for adding tasks", "4192ab0d-b447-4cbe-8ec9-355ec9dfa86d", "Create Tasks" },
                    { new Guid("8f9a04db-5163-49e5-8587-fb2480d6a79e"), 1, new DateTime(2023, 1, 8, 22, 58, 28, 682, DateTimeKind.Utc).AddTicks(6352), "Create Android client App for the Restfull TaskBoard Service", "b6a8cf17-27fe-4a4b-80dc-ad92c21837d4", "Android Client App" },
                    { new Guid("a8250314-b531-4df4-8762-8e8f2de7b6ff"), 1, new DateTime(2022, 11, 20, 22, 58, 28, 682, DateTimeKind.Utc).AddTicks(6337), "Implement better styling for all public pages", "4192ab0d-b447-4cbe-8ec9-355ec9dfa86d", "Improve CSS style" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_BoardId",
                table: "Tasks",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_OwnerId",
                table: "Tasks",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Boards");
        }
    }
}
