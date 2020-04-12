using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCProject2.Migrations
{
    public partial class fixMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Comments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Comments",
                nullable: true);
        }
    }
}
