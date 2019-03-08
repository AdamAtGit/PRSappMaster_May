using Microsoft.EntityFrameworkCore.Migrations;

namespace PRSapp.Model.Migrations
{
    public partial class _2classesNqRecordSetClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayLists",
                columns: table => new
                {
                    PlayListId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Uses = table.Column<string>(nullable: true),
                    Repeats = table.Column<int>(nullable: false),
                    ShuffleIsOn = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayLists", x => x.PlayListId);
                });

            migrationBuilder.CreateTable(
                name: "PlayListItems",
                columns: table => new
                {
                    PlayListItemId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemTitleId = table.Column<int>(nullable: false),
                    ItemTitleName = table.Column<string>(nullable: true),
                    Priority = table.Column<int>(nullable: false),
                    PlayPositions = table.Column<int>(nullable: false),
                    PlayListId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayListItems", x => x.PlayListItemId);
                    table.ForeignKey(
                        name: "FK_PlayListItems_PlayLists_PlayListId",
                        column: x => x.PlayListId,
                        principalTable: "PlayLists",
                        principalColumn: "PlayListId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayListItems_PlayListId",
                table: "PlayListItems",
                column: "PlayListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayListItems");

            migrationBuilder.DropTable(
                name: "PlayLists");
        }
    }
}
