using Microsoft.EntityFrameworkCore.Migrations;

namespace webApi.Data.Migrations
{
    public partial class Event : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            
            
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Event",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "date",
                table: "Event",
                nullable: true);
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Event",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "date",
                table: "Event");

            migrationBuilder.RenameTable(
                name: "Event",
                newName: "Events");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                table: "Events",
                column: "Id");
        }
    }
}
