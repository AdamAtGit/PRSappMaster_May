using Microsoft.EntityFrameworkCore.Migrations;

namespace PRSapp.Model.Migrations
{
    public partial class RenameUserUserNameToUserFirstName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "UserFirstName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserFirstName",
                table: "Users",
                newName: "UserName");
        }
    }
}
