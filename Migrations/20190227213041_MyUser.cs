using Microsoft.EntityFrameworkCore.Migrations;

namespace webApi.Migrations
{
    public partial class MyUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "other_email",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "other_email",
                table: "AspNetUsers");
        }
    }
}
