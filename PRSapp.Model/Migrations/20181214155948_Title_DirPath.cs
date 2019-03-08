using Microsoft.EntityFrameworkCore.Migrations;

namespace PRSapp.Model.Migrations
{
    public partial class Title_DirPath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DirPath",
                table: "Titles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DirPath",
                table: "Titles");
        }
    }
}
