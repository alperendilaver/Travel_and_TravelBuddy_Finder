using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class matches : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_AspNetUsers_FirstUserId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_AspNetUsers_SecondUserId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "FirtsUserId",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "SecondUserId",
                table: "Matches",
                newName: "LikerId");

            migrationBuilder.RenameColumn(
                name: "FirstUserId",
                table: "Matches",
                newName: "LikeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_SecondUserId",
                table: "Matches",
                newName: "IX_Matches_LikerId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_FirstUserId",
                table: "Matches",
                newName: "IX_Matches_LikeeId");

            migrationBuilder.AddColumn<bool>(
                name: "IsLiked",
                table: "Matches",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsMatched",
                table: "Matches",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_AspNetUsers_LikeeId",
                table: "Matches",
                column: "LikeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_AspNetUsers_LikerId",
                table: "Matches",
                column: "LikerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_AspNetUsers_LikeeId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_AspNetUsers_LikerId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "IsLiked",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "IsMatched",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "LikerId",
                table: "Matches",
                newName: "SecondUserId");

            migrationBuilder.RenameColumn(
                name: "LikeeId",
                table: "Matches",
                newName: "FirstUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_LikerId",
                table: "Matches",
                newName: "IX_Matches_SecondUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_LikeeId",
                table: "Matches",
                newName: "IX_Matches_FirstUserId");

            migrationBuilder.AddColumn<string>(
                name: "FirtsUserId",
                table: "Matches",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_AspNetUsers_FirstUserId",
                table: "Matches",
                column: "FirstUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_AspNetUsers_SecondUserId",
                table: "Matches",
                column: "SecondUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
