CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

CREATE TABLE "Users" (
    "UserId" INTEGER NOT NULL CONSTRAINT "PK_Users" PRIMARY KEY AUTOINCREMENT,
    "UserLogin" TEXT NULL
);

CREATE TABLE "Titles" (
    "TitleId" INTEGER NOT NULL CONSTRAINT "PK_Titles" PRIMARY KEY AUTOINCREMENT,
    "TitleName" TEXT NULL,
    "TtsRaw" TEXT NULL,
    "UserId" INTEGER NOT NULL,
    CONSTRAINT "FK_Titles_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("UserId") ON DELETE CASCADE
);

CREATE INDEX "IX_Titles_UserId" ON "Titles" ("UserId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20181213220723_InitialCreate', '2.1.4-rtm-31024');

ALTER TABLE "Titles" ADD "DirPath" TEXT NULL;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20181214155948_Title_DirPath', '2.1.4-rtm-31024');

CREATE TABLE "PlayLists" (
    "PlayListId" INTEGER NOT NULL CONSTRAINT "PK_PlayLists" PRIMARY KEY AUTOINCREMENT,
    "UserId" INTEGER NOT NULL,
    "Name" TEXT NULL,
    "Uses" TEXT NULL,
    "Repeats" INTEGER NOT NULL,
    "ShuffleIsOn" INTEGER NOT NULL
);

CREATE TABLE "PlayListItems" (
    "PlayListItemId" INTEGER NOT NULL CONSTRAINT "PK_PlayListItems" PRIMARY KEY AUTOINCREMENT,
    "ItemTitleId" INTEGER NOT NULL,
    "ItemTitleName" TEXT NULL,
    "Priority" INTEGER NOT NULL,
    "PlayPositions" INTEGER NOT NULL,
    "PlayListId" INTEGER NOT NULL,
    CONSTRAINT "FK_PlayListItems_PlayLists_PlayListId" FOREIGN KEY ("PlayListId") REFERENCES "PlayLists" ("PlayListId") ON DELETE CASCADE
);

CREATE INDEX "IX_PlayListItems_PlayListId" ON "PlayListItems" ("PlayListId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20181226025451_2classesNqRecordSetClass', '2.1.4-rtm-31024');

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20181226030938_2classesNqRecordSetClassPlayListId', '2.1.4-rtm-31024');

