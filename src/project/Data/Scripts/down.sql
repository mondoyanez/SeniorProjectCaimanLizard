ALTER TABLE [FollowingList]                 DROP CONSTRAINT [Fk_FollowingList_UserID]
ALTER TABLE [FollowingList]                 DROP CONSTRAINT [Fk_FollowingList_FollowingID]

ALTER TABLE [Post]                          DROP CONSTRAINT [Fk_Post_UserID]
ALTER TABLE [Comment]                       DROP CONSTRAINT [Fk_Comment_PostID]

ALTER TABLE [Comment]                       DROP CONSTRAINT [Fk_Comment_UserID]

ALTER TABLE [Reshare]                       DROP CONSTRAINT [Fk_Reshare_PostID]
ALTER TABLE [Reshare]                       DROP CONSTRAINT [Fk_Reshare_UserID]

ALTER TABLE [LikePost]                      DROP CONSTRAINT [Fk_LikePost_PostID]
ALTER TABLE [LikePost]                      DROP CONSTRAINT [Fk_LikePost_UserID]

ALTER TABLE [WatchList]                     DROP CONSTRAINT [Fk_WatchList_UserID]

ALTER TABLE [WatchListItems]                DROP CONSTRAINT [Fk_WatchListItems_WatchList]
ALTER TABLE [WatchListItems]                DROP CONSTRAINT [Fk_WatchListItems_Show]
ALTER TABLE [WatchListItems]                DROP CONSTRAINT [Fk_WatchListItems_Movie]

ALTER TABLE [WatchPartyGroup]               DROP CONSTRAINT [Fk_WatchPartyGroup_Watcher]

ALTER TABLE [WatchPartyGroupAssignment]     DROP CONSTRAINT [Fk_WatchPartyGroupAssignment_WatchPartyGroup]
ALTER TABLE [WatchPartyGroupAssignment]     DROP CONSTRAINT [Fk_WatchPartyGroupAssignment_Watcher]

ALTER TABLE [Notification]          DROP CONSTRAINT [Fk_Notification_NotifierID]
ALTER TABLE [Notification]          DROP CONSTRAINT [Fk_Notification_NotifTypeID]

DROP TABLE [Watcher];
DROP TABLE [FollowingList];
DROP TABLE [Post];
DROP TABLE [Comment];
DROP TABLE [Reshare];
DROP TABLE [LikePost];
DROP TABLE [WatchList];
DROP TABLE [Show];
DROP TABLE [Movie];
DROP TABLE [WatchListItems];
DROP TABLE [WatchPartyGroup];
DROP TABLE [WatchPartyGroupAssignment];
DROP TABLE [Notification];
DROP TABLE [NotificationType];

-- DROP DATABASE WatchParty;