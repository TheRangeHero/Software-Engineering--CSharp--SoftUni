using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumApp.Data.Migrations
{
    public partial class CreateAndSeedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "Title" },
                values: new object[] { new Guid("4b938849-3b01-4440-ab79-eb7d644ad5cf"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin tristique urna neque, a porta libero volutpat ac. Nulla pulvinar.", "My third" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "Title" },
                values: new object[] { new Guid("a0563f9a-90dd-445a-b598-ee39b77ab875"), "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...", "My second post" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "Title" },
                values: new object[] { new Guid("bd8d53e9-508d-484c-a9ba-23c4409f011e"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec at libero maximus, gravida diam ac, blandit nisl. Curabitur vehicula diam.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec at libero maximus, gravida diam ac, blandit nisl. Curabitur vehicula diam.", "My first post" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
