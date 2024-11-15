using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class changenots : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notification_AspNetUsers_ReceiverId",
                table: "Notification");

            migrationBuilder.DropIndex(
                name: "IX_Notification_ReceiverId",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "Notification");

            migrationBuilder.AlterColumn<string>(
                name: "ReceiverUserId",
                table: "Notification",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_ReceiverUserId",
                table: "Notification",
                column: "ReceiverUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_AspNetUsers_ReceiverUserId",
                table: "Notification",
                column: "ReceiverUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notification_AspNetUsers_ReceiverUserId",
                table: "Notification");

            migrationBuilder.DropIndex(
                name: "IX_Notification_ReceiverUserId",
                table: "Notification");

            migrationBuilder.AlterColumn<string>(
                name: "ReceiverUserId",
                table: "Notification",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ReceiverId",
                table: "Notification",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_ReceiverId",
                table: "Notification",
                column: "ReceiverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_AspNetUsers_ReceiverId",
                table: "Notification",
                column: "ReceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
