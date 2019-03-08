using Microsoft.EntityFrameworkCore.Migrations;

namespace PRSapp.Model.Migrations
{
    public partial class RenameUserUserNameToUserFirstName : Migration
    {
        #region before/after
        /////Before protected override void Up(MigrationBuilder migrationBuilder)
        //protected override void Up(MigrationBuilder migrationBuilder)
        //{
        //    migrationBuilder.RenameColumn(
        //        name: "UserName",
        //        table: "Users",
        //        newName: "UserFirstName");
        //}

        //////After
        //source origin for modify migration to manually rename column in below Method
        //https://elanderson.net/2017/04/entity-framework-core-with-sqlite-migration-limitations/
        protected override void Up(MigrationBuilder migrationBuilder)
        {   
            migrationBuilder.Sql(
                @"PRAGMA foreign_keys = 0;

              CREATE TABLE Users_temp AS SELECT *
                                            FROM Users;
              
              DROP TABLE Users;
              
              CREATE TABLE Users (
                  UserId         INTEGER NOT NULL
                                     CONSTRAINT PK_Users PRIMARY KEY AUTOINCREMENT,                              
                  UserFirstName  TEXT
              );
              
              INSERT INTO Users 
              (
                  UserId,                
                  UserFirstName
              )
              SELECT UserId,                  
                     UserName
              FROM Users_temp;
              
              DROP TABLE Users_temp;
              
              PRAGMA foreign_keys = 1;");
        }
        #endregion

        protected override void Down(MigrationBuilder migrationBuilder)
        {          
        }
    }
}
