ALTER TABLE [Post]                  DROP CONSTRAINT [Fk_Post_UserID]

ALTER TABLE [Reshare]               DROP CONSTRAINT [Fk_Reshare_PostID]
ALTER TABLE [Reshare]               DROP CONSTRAINT [Fk_Reshare_UserID]

ALTER TABLE [LikePost]              DROP CONSTRAINT [Fk_LikePost_PostID]
ALTER TABLE [LikePost]              DROP CONSTRAINT [Fk_LikePost_UserID]

ALTER TABLE [WatchList]             DROP CONSTRAINT [Fk_WatchList_UserID]

ALTER TABLE [WatchListItems]        DROP CONSTRAINT [Fk_WatchListItems_WatchList]
ALTER TABLE [WatchListItems]        DROP CONSTRAINT [Fk_WatchListItems_Show]
ALTER TABLE [WatchListItems]        DROP CONSTRAINT [Fk_WatchListItems_Movie]

DROP TABLE [Watcher];
DROP TABLE [Post];
DROP TABLE [Reshare];
DROP TABLE [LikePost];
DROP TABLE [WatchList];
DROP TABLE [Show];
DROP TABLE [Movie];
DROP TABLE [WatchListItems];

-- DROP DATABASE WatchParty;