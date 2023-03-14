ALTER TABLE [Post]                  DROP CONSTRAINT [Fk_Post_UserID]

ALTER TABLE [Reshare]               DROP CONSTRAINT [Fk_Reshare_PostID]
ALTER TABLE [Reshare]               DROP CONSTRAINT [Fk_Reshare_UserID]

ALTER TABLE [LikePost]              DROP CONSTRAINT [Fk_LikePost_PostID]
ALTER TABLE [LikePost]              DROP CONSTRAINT [Fk_LikePost_UserID]

ALTER TABLE [WatchList]             DROP CONSTRAINT [Fk_WatchList_UserID]
ALTER TABLE [WatchList]             DROP CONSTRAINT [Fk_WatchList_ShowID]
ALTER TABLE [WatchList]             DROP CONSTRAINT [Fk_WatchList_MovieID]



DROP TABLE [Watcher];
DROP TABLE [Post];
DROP TABLE [Reshare];
DROP TABLE [LikePost];
DROP TABLE [WatchList];
DROP TABLE [Show];
DROP TABLE [Movie];

-- DROP DATABASE WatchParty;