using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class addcrypto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Message",
                table: "ChatMessages",
                newName: "EncryptedMessageForSender");

            migrationBuilder.AddColumn<string>(
                name: "EncryptedMessageForReceiver",
                table: "ChatMessages",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EncryptedMessageForReceiver",
                table: "ChatMessages");

            migrationBuilder.RenameColumn(
                name: "EncryptedMessageForSender",
                table: "ChatMessages",
                newName: "Message");
        }
    }
}
