using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class changenot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notification_AspNetUsers_AppUserId",
                table: "Notification");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Notification",
                newName: "ReceiverUserId");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Notification",
                newName: "ReceiverId");

            migrationBuilder.RenameIndex(
                name: "IX_Notification_AppUserId",
                table: "Notification",
                newName: "IX_Notification_ReceiverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_AspNetUsers_ReceiverId",
                table: "Notification",
                column: "ReceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notification_AspNetUsers_ReceiverId",
                table: "Notification");

            migrationBuilder.RenameColumn(
                name: "ReceiverUserId",
                table: "Notification",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ReceiverId",
                table: "Notification",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Notification_ReceiverId",
                table: "Notification",
                newName: "IX_Notification_AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_AspNetUsers_AppUserId",
                table: "Notification",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
