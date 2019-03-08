using Microsoft.EntityFrameworkCore.Migrations;

namespace PRSapp.Model.Migrations
{
    public partial class AddColumnUserPwdToUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserPwd",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserPwd",
                table: "Users");
        }
    }
}
