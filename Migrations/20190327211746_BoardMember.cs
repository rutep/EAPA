using Microsoft.EntityFrameworkCore.Migrations;

namespace webApi.Migrations
{
    public partial class BoardMember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "text",
                table: "BoardMember",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "text",
                table: "BoardMember");
        }
    }
}
