using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameManager.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_GameConsoles_ConsoleId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Genres_GenreId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Publishers_PublisherId",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "PublisherId",
                table: "Games",
                newName: "IdPublisher");

            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "Games",
                newName: "IdGenre");

            migrationBuilder.RenameColumn(
                name: "ConsoleId",
                table: "Games",
                newName: "IdConsole");

            migrationBuilder.RenameIndex(
                name: "IX_Games_PublisherId",
                table: "Games",
                newName: "IX_Games_IdPublisher");

            migrationBuilder.RenameIndex(
                name: "IX_Games_GenreId",
                table: "Games",
                newName: "IX_Games_IdGenre");

            migrationBuilder.RenameIndex(
                name: "IX_Games_ConsoleId",
                table: "Games",
                newName: "IX_Games_IdConsole");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Games",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_GameConsoles_IdConsole",
                table: "Games",
                column: "IdConsole",
                principalTable: "GameConsoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Genres_IdGenre",
                table: "Games",
                column: "IdGenre",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Publishers_IdPublisher",
                table: "Games",
                column: "IdPublisher",
                principalTable: "Publishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_GameConsoles_IdConsole",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Genres_IdGenre",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Publishers_IdPublisher",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "IdPublisher",
                table: "Games",
                newName: "PublisherId");

            migrationBuilder.RenameColumn(
                name: "IdGenre",
                table: "Games",
                newName: "GenreId");

            migrationBuilder.RenameColumn(
                name: "IdConsole",
                table: "Games",
                newName: "ConsoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_IdPublisher",
                table: "Games",
                newName: "IX_Games_PublisherId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_IdGenre",
                table: "Games",
                newName: "IX_Games_GenreId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_IdConsole",
                table: "Games",
                newName: "IX_Games_ConsoleId");

            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "Games",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_GameConsoles_ConsoleId",
                table: "Games",
                column: "ConsoleId",
                principalTable: "GameConsoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Genres_GenreId",
                table: "Games",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Publishers_PublisherId",
                table: "Games",
                column: "PublisherId",
                principalTable: "Publishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
