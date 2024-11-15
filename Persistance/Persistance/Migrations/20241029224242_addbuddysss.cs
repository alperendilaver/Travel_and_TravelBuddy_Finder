using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class addbuddysss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuggestedUsers_AspNetUsers_UserId",
                table: "SuggestedUsers");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "SuggestedUsers",
                newName: "RequestingUserId");

            migrationBuilder.RenameIndex(
                name: "IX_SuggestedUsers_UserId",
                table: "SuggestedUsers",
                newName: "IX_SuggestedUsers_RequestingUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SuggestedUsers_AspNetUsers_RequestingUserId",
                table: "SuggestedUsers",
                column: "RequestingUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuggestedUsers_AspNetUsers_RequestingUserId",
                table: "SuggestedUsers");

            migrationBuilder.RenameColumn(
                name: "RequestingUserId",
                table: "SuggestedUsers",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_SuggestedUsers_RequestingUserId",
                table: "SuggestedUsers",
                newName: "IX_SuggestedUsers_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SuggestedUsers_AspNetUsers_UserId",
                table: "SuggestedUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
