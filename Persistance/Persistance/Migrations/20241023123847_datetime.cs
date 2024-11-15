using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class datetime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DestinationHobbies");

            migrationBuilder.AddColumn<DateTime>(
                name: "PostedTime",
                table: "Posts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostedTime",
                table: "Posts");

            migrationBuilder.CreateTable(
                name: "DestinationHobbies",
                columns: table => new
                {
                    DestinationHobbyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HobbyId = table.Column<int>(type: "int", nullable: false),
                    TravelDestinationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestinationHobbies", x => x.DestinationHobbyId);
                    table.ForeignKey(
                        name: "FK_DestinationHobbies_Hobbies_HobbyId",
                        column: x => x.HobbyId,
                        principalTable: "Hobbies",
                        principalColumn: "HobbyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DestinationHobbies_TravelDestinations_TravelDestinationId",
                        column: x => x.TravelDestinationId,
                        principalTable: "TravelDestinations",
                        principalColumn: "TravelDestinationId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_DestinationHobbies_HobbyId",
                table: "DestinationHobbies",
                column: "HobbyId");

            migrationBuilder.CreateIndex(
                name: "IX_DestinationHobbies_TravelDestinationId",
                table: "DestinationHobbies",
                column: "TravelDestinationId");
        }
    }
}
