using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameManager.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateFromScripts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_GameConsoles_ConsoleId",
                table: "Games");

            migrationBuilder.DropTable(
                name: "GameConsoles");

            migrationBuilder.CreateTable(
                name: "Console",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Console", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Console_ConsoleId",
                table: "Games",
                column: "ConsoleId",
                principalTable: "Console",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Console_ConsoleId",
                table: "Games");

            migrationBuilder.DropTable(
                name: "Console");

            migrationBuilder.CreateTable(
                name: "GameConsoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameConsoles", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Games_GameConsoles_ConsoleId",
                table: "Games",
                column: "ConsoleId",
                principalTable: "GameConsoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
