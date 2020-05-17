using Microsoft.EntityFrameworkCore.Migrations;

namespace VGListRazor.Migrations
{
    public partial class AddPublishertoModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "publisher",
                table: "Game",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "publisher",
                table: "Game");
        }
    }
}
