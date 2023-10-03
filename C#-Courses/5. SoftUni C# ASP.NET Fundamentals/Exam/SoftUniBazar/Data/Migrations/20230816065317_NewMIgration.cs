using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftUniBazar.Data.Migrations
{
    public partial class NewMIgration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdsBuyers_Categories_CategoryId",
                table: "AdsBuyers");

            migrationBuilder.DropIndex(
                name: "IX_AdsBuyers_CategoryId",
                table: "AdsBuyers");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "AdsBuyers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "AdsBuyers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdsBuyers_CategoryId",
                table: "AdsBuyers",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdsBuyers_Categories_CategoryId",
                table: "AdsBuyers",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
