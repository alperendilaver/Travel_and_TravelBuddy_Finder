using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class addbuddyssAsqq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuggestedUsers_AspNetUsers_AppUserId",
                table: "SuggestedUsers");

            migrationBuilder.DropIndex(
                name: "IX_SuggestedUsers_AppUserId",
                table: "SuggestedUsers");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "SuggestedUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "SuggestedUsers",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_SuggestedUsers_AppUserId",
                table: "SuggestedUsers",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SuggestedUsers_AspNetUsers_AppUserId",
                table: "SuggestedUsers",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
