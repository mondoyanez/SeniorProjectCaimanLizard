-- CREATE DATABASE WatchPartyDB

CREATE TABLE [Watcher] 
(
    [ID]                    INT                 NOT NULL PRIMARY KEY IDENTITY(1,1),
    [FirstName]             NVARCHAR(64)        NOT NULL,
    [LastName]              NVARCHAR(64)        NOT NULL,
    [Email]                 NVARCHAR(64)
);

CREATE TABLE [Post]
(
    [ID]                    INT                 NOT NULL PRIMARY KEY IDENTITY(1,1),
    [PostTitle]             NVARCHAR(2048)      NOT NULL,
    [PostDescription]       NVARCHAR(2048)      NOT NULL,
    [DatePosted]            DATETIME            NOT NULL,

    [UserID]                INT                 NOT NULL
);

CREATE TABLE [Reshare]
(
    [ID]                    INT                 NOT NULL PRIMARY KEY IDENTITY(1,1),
    
    [PostID]                INT                 NOT NULL,
    [UserID]                INT                 NOT NULL
);

CREATE TABLE [LikePost]
(
    [ID]                    INT                 NOT NULL PRIMARY KEY IDENTITY(1,1),

    [PostID]                INT                 NOT NULL,
    [UserID]                INT                 NOT NULL
);
