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

ALTER TABLE [Post]                  ADD CONSTRAINT [Fk_Post_UserID]                 FOREIGN KEY([UserID])                   REFERENCES[Watcher]([ID])           ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE [Reshare]               ADD CONSTRAINT [Fk_Reshare_PostID]              FOREIGN KEY([PostID])                   REFERENCES[Post]([ID])              ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [Reshare]               ADD CONSTRAINT [Fk_Reshare_UserID]              FOREIGN KEY([UserID])                   REFERENCES[Watcher]([ID])           ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE [LikePost]              ADD CONSTRAINT [Fk_LikePost_PostID]             FOREIGN KEY([PostID])                   REFERENCES[Post]([ID])              ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [LikePost]              ADD CONSTRAINT [Fk_LikePost_UserID]             FOREIGN KEY([UserID])                   REFERENCES[Watcher]([ID])           ON DELETE NO ACTION ON UPDATE NO ACTION;