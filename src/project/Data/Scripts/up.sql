-- CREATE DATABASE WatchParty

CREATE TABLE [Watcher] 
(
    [Id]                    INT                 NOT NULL PRIMARY KEY IDENTITY(1,1),
    [AspNetIdentityId]      NVARCHAR(450)       NOT NULL,
    [Username]              NVARCHAR(256)       NOT NULL,
    [FirstName]             NVARCHAR(64),
    [LastName]              NVARCHAR(64),
    [Email]                 NVARCHAR(256),
    [Bio]                   NVARCHAR(256),
    [WatchListPrivacy]      BIT                NOT NULL
);

CREATE TABLE [FollowingList]
(
    [ID]                    INT                 NOT NULL PRIMARY KEY IDENTITY(1,1),
    [UserID]                INT                 NOT NULL,
    [FollowingID]           INT                 NOT NULL
);

CREATE TABLE [Post]
(
    [ID]                    INT                 NOT NULL PRIMARY KEY IDENTITY(1,1),
    [PostTitle]             NVARCHAR(2048)      NOT NULL,
    [PostDescription]       NVARCHAR(2048),
    [DatePosted]            DATETIME            NOT NULL,
    [IsVisible]             BIT                 NOT NULL,

    [UserID]                INT                 NOT NULL
);

CREATE TABLE [Comment]
(
    [ID]                    INT                 NOT NULL PRIMARY KEY IDENTITY(1,1),
    [CommentTitle]          NVARCHAR(2048)      NOT NULL,
    [DatePosted]            DATETIME            NOT NULL,
    [IsVisible]             BIT                 NOT NULL,

    [UserID]                INT                 NOT NULL,
    [PostID]                INT                 NOT NULL
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

CREATE TABLE [WatchList]
(
    [ID]                    INT                 NOT NULL PRIMARY KEY IDENTITY(1,1),
    [UserID]                INT                 NOT NULL,
    [ListType]                  INT
);


CREATE TABLE [Show]
(
    [ID]                    INT                 NOT NULL PRIMARY KEY IDENTITY(1,1),
    [TMDBID]                INT                 NOT NULL,
    [Title]                 NVARCHAR(128)       NOT NULL,
    [Overview]              NVARCHAR(2048),
    [FirstAirDate]          NVARCHAR(32)
);

CREATE TABLE [Movie]
(
    [ID]                    INT                 NOT NULL PRIMARY KEY IDENTITY(1,1),
    [TMDBID]                INT                 NOT NULL,
    [Title]                 NVARCHAR(128)       NOT NULL,
    [Overview]              NVARCHAR(2048),
    [ReleaseDate]           NVARCHAR(32)
);

CREATE TABLE [WatchListItems]
(
    [ID]                    INT                 NOT NULL PRIMARY KEY IDENTITY(1,1),
    [WatchListID]           INT                 NOT NULL,
    [ShowID]                INT,
    [MovieID]               INT
);

CREATE TABLE [Notification]
(
    [ID]                    INT                 NOT NULL PRIMARY KEY IDENTITY(1,1),
    [NotifierID]            INT                 NOT NULL,
    [NotifTypeID]           INT                 NOT NULL,
    [Content]               NVARCHAR(256)       NOT NULL,
    [IsRead]                BIT                 NOT NULL,
    [CreatedAt]             DATETIME            NOT NULL
);

CREATE TABLE [NotificationType] 
(
    [ID]                    INT                 NOT NULL PRIMARY KEY IDENTITY(1,1),
    [NType]                 NVARCHAR(256)       NOT NULL
);

CREATE TABLE [WatchPartyGroup]
(
    [ID]                    INT                 NOT NULL PRIMARY KEY IDENTITY(1,1),
    [GroupTitle]            NVARCHAR(512)       NOT NULL,
    [GroupDescription]      NVARCHAR(1024),
    [StartDate]             DATETIME            NOT NULL,

    [HostID]                INT                 NOT NULL
);

CREATE TABLE [WatchPartyGroupAssignment]
(
    [ID]                    INT                 NOT NULL PRIMARY KEY IDENTITY(1,1),

    [GroupID]               INT                 NOT NULL,
    [WatcherID]             INT                 NOT NULL
);

ALTER TABLE [Post]                          ADD CONSTRAINT [Fk_Post_UserID]                                     FOREIGN KEY([UserID])                   REFERENCES[Watcher]([Id])           ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE [Comment]                       ADD CONSTRAINT [Fk_Comment_UserID]                                  FOREIGN KEY([UserID])                   REFERENCES[Watcher]([Id])           ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [Comment]                       ADD CONSTRAINT [Fk_Comment_PostID]                                  FOREIGN KEY([PostID])                   REFERENCES[Post]([Id])              ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE [FollowingList]                 ADD CONSTRAINT [Fk_FollowingList_UserID]                            FOREIGN KEY([UserID])                   REFERENCES[Watcher]([Id])           ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [FollowingList]                 ADD CONSTRAINT [Fk_FollowingList_FollowingID]                       FOREIGN KEY([FollowingID])              REFERENCES[Watcher]([Id])           ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE [Reshare]                       ADD CONSTRAINT [Fk_Reshare_PostID]                                  FOREIGN KEY([PostID])                   REFERENCES[Post]([ID])              ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [Reshare]                       ADD CONSTRAINT [Fk_Reshare_UserID]                                  FOREIGN KEY([UserID])                   REFERENCES[Watcher]([ID])           ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE [LikePost]                      ADD CONSTRAINT [Fk_LikePost_PostID]                                 FOREIGN KEY([PostID])                   REFERENCES[Post]([ID])              ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [LikePost]                      ADD CONSTRAINT [Fk_LikePost_UserID]                                 FOREIGN KEY([UserID])                   REFERENCES[Watcher]([ID])           ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE [WatchList]                     ADD CONSTRAINT [Fk_WatchList_UserID]                                FOREIGN KEY([UserID])                   REFERENCES[Watcher]([ID])           ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE [WatchListItems]                ADD CONSTRAINT [Fk_WatchListItems_WatchList]                        FOREIGN KEY([WatchListID])              REFERENCES[WatchList]([ID])         ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [WatchListItems]                ADD CONSTRAINT [Fk_WatchListItems_Show]                             FOREIGN KEY([ShowID])                   REFERENCES[Show]([ID])              ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [WatchListItems]                ADD CONSTRAINT [Fk_WatchListItems_Movie]                            FOREIGN KEY([MovieID])                  REFERENCES[Movie]([ID])             ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE [WatchPartyGroup]               ADD CONSTRAINT [Fk_WatchPartyGroup_Watcher]                         FOREIGN KEY([HostID])                   REFERENCES[Watcher]([ID])           ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE [WatchPartyGroupAssignment]     ADD CONSTRAINT [Fk_WatchPartyGroupAssignment_WatchPartyGroup]       FOREIGN KEY([GroupID])                  REFERENCES[WatchPartyGroup]([ID])   ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [WatchPartyGroupAssignment]     ADD CONSTRAINT [Fk_WatchPartyGroupAssignment_Watcher]               FOREIGN KEY([WatcherID])                REFERENCES[Watcher]([ID])           ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE [Notification]                  ADD CONSTRAINT [Fk_Notification_NotifierID]                         FOREIGN KEY([NotifierID])               REFERENCES[Watcher]([Id])           ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [Notification]                  ADD CONSTRAINT [Fk_Notification_NotifTypeID]                        FOREIGN KEY([NotifTypeID])              REFERENCES[NotificationType]([ID])  ON DELETE NO ACTION ON UPDATE NO ACTION;