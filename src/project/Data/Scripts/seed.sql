SET IDENTITY_INSERT [Watcher] ON;
INSERT INTO [Watcher](ID, AspNetIdentityId, Username, FirstName, LastName, Email, Bio, WatchListPrivacy)
VALUES
(1, '571e79b0-24be-4f8b-96dd-056b493cd7c5', 'SandraHart', 'Sandra', 'Hart', 'SandraHart@email.com', NULL, 1),
(2, '231e79b0-24be-4f8b-96dd-056b493cd7c5', 'CarsonDaniel', 'Carson', 'Daniel', 'DanielCarson@domain.net', NULL, 1),
(3, '681e79b0-24be-4f8b-96dd-056b493cd7c5', 'PaigeCole', 'Paige', 'Cole', null, NULL, 0),
(4, '561e79b0-24be-4f8b-96dd-056b493cd7c4', 'JaysonLawrence', 'Jayson', 'Lawrence', 'jLawrence@name.edu', NULL, 0),
(5, '561e79b0-24be-4f8b-96dd-056b493cd7e5', 'GabrielGrant', 'Gabriel', 'Grant', 'gGabriel@differentMail.com', NULL, 0),
(6, '561e79b0-24be-4f8b-96dd-056b493cd6c5', 'BradPorter', 'Brad', 'Porter', 'BradPorter@email.com', NULL, 0),
(7, '561e79b0-24be-4f8b-96dd-056b493cd7p5', 'JudsonCooke', 'Judson', 'Cooke', null, NULL, 0),
(8, '561e79b1-24be-4f8b-96dd-056b493cd7c5', 'SofiaCarpenter', 'Sofia', 'Carpenter', 'CarpenterSofia@mail.org', NULL, 0),
(9, '561e79b0-24bf-4f8b-96dd-056b493cd7c5', 'JosefMeyer', 'Josef', 'Meyer', 'JosefMeyer@mail.edu', NULL, 0),
(10, '561e79b0-24be-4f8b-96dd-056b593cd7c5', 'BobbieMcintyre', 'Bobbie', 'Mcintyre', null, NULL, 0);
SET IDENTITY_INSERT [Watcher] OFF;

SET IDENTITY_INSERT [FollowingList] ON;
INSERT INTO [FollowingList](ID, UserID, FollowingID)
VALUES
(1, 1, 2),
(2, 1, 3),
(3, 1, 4),
(4, 1, 5),
(5, 1, 6),
(6, 1, 7),
(7, 1, 8),
(8, 1, 9),
(9, 1, 10),
(10, 2, 1),
(11, 2, 3),
(12, 2, 5),
(13, 2, 7),
(14, 2, 9),
(15, 3, 2),
(16, 3, 4),
(17, 3, 6),
(18, 3, 8),
(19, 3, 10),
(20, 4, 3),
(21, 4, 6),
(22, 4, 9),
(23, 5, 3),
(24, 5, 4),
(25, 5, 6),
(26, 5, 7),
(27, 5, 8),
(28, 5, 9),
(29, 5, 10),
(30, 6, 3),
(31, 6, 5),
(32, 6, 7),
(33, 6, 9),
(34, 7, 3),
(35, 7, 2),
(36, 7, 4),
(37, 7, 6),
(38, 7, 8),
(39, 7, 10),
(40, 8, 3),
(41, 8, 7),
(42, 8, 10),
(43, 9, 1),
(44, 9, 3),
(45, 9, 5),
(46, 9, 7),
(47, 9, 10);
SET IDENTITY_INSERT [FollowingList] OFF;

SET IDENTITY_INSERT [Post] ON;
INSERT INTO [Post](ID, PostTitle, PostDescription, DatePosted, IsVisible, UserID)
VALUES
(1, 'That new Ant-man movie was incredible!', null, '2023-01-15 17:00:00', 1, 1),
(2, 'Spider-man', 'So excited for the new spider man movies!', '2023-02-01 15:00:00', 1, 3),
(3, 'Friends', 'By far one of my favorite shows', '2023-02-08 08:00:00', 1, 5),
(4, 'Best comedy of 2023?', null, '2022-12-25 12:00:00', 1, 7),
(5, 'Might have been the best movie released in a while', null, '2023-02-03 13:00:00', 1, 2),
(6, 'Who wants to watch a movie later', null, '2023-01-15 17:00:00', 0, 6),
(7, 'The office was a good show', 'It was increible unlike anything else I''ve seen before', '2023-01-15 17:00:00', 0, 9),
(8, 'Friends with friends', null, '2023-01-15 17:00:00', 1, 10),
(9, 'MCU marathon', 'Who is down to have a MCU marathon sometime next week?', '2023-01-15 17:00:00', 1, 8),
(10, 'Avatar', 'Excited to watch the new Avatar movie that came out', '2023-01-15 17:00:00', 1, 4)
SET IDENTITY_INSERT [Post] OFF;

SET IDENTITY_INSERT [Comment] ON;
INSERT INTO [Comment](ID, CommentTitle, DatePosted, IsVisible, UserID, PostID)
VALUES
(1, 'I also thought that Friends was a great show', '2023-04-02 13:25:00', 1, 2, 3),
(2, 'I thought it was ok', '2023-04-02 14:00:00', 1, 3, 3),
(3, 'I respect your opinion @PagieCole', '2023-04-02 14:10:00', 0, 1, 3)
SET IDENTITY_INSERT [Comment] OFF;

SET IDENTITY_INSERT [Reshare] ON;
INSERT INTO [Reshare] (ID, PostID, UserID)
VALUES
(1, 1, 2),
(2, 1, 5),
(3, 2, 7),
(4, 2, 10),
(5, 3, 6),
(6, 3, 8),
(7, 4, 1),
(8, 4, 2),
(9, 5, 3),
(10, 5, 5),
(11, 6, 9),
(12, 6, 7),
(13, 7, 10),
(14, 7, 5),
(15, 8, 3),
(16, 8, 5),
(17, 9, 1),
(18, 9, 9),
(19, 10, 7),
(20, 10, 3)
SET IDENTITY_INSERT [Reshare] OFF;

SET IDENTITY_INSERT [LikePost] ON;
INSERT INTO [LikePost] (ID, PostID, UserID)
VALUES
(1, 1, 2),
(2, 1, 5),
(3, 2, 7),
(4, 2, 10),
(5, 3, 6),
(6, 3, 8),
(7, 4, 1),
(8, 4, 2),
(9, 5, 3),
(10, 5, 5),
(11, 6, 9),
(12, 6, 7),
(13, 7, 10),
(14, 7, 5),
(15, 8, 3),
(16, 8, 5),
(17, 9, 1),
(18, 9, 9),
(19, 10, 7),
(20, 10, 3)
SET IDENTITY_INSERT [LikePost] OFF;

SET IDENTITY_INSERT [Show] ON;
INSERT INTO [Show] (ID, TMDBID, Title, Overview, FirstAirDate)
VALUES
(1, 100088, 'The Last of us', 'Twenty years after modern civilization has been destroyed, Joel, a hardened survivor, is hired to smuggle Ellie, a 14-year-old girl, out of an oppressive quarantine zone. What starts as a small job soon becomes a brutal, heartbreaking journey, as they both must traverse the United States and depend on each other for survival.', '2023-01-15'),
(2, 82856, 'The Mandalorian', 'After the fall of the Galactic Empire, lawlessness has spread throughout the galaxy. A lone gunfighter makes his way through the outer reaches, earning his keep as a bounty hunter.', '2019-11-12')
SET IDENTITY_INSERT [Show] OFF;

SET IDENTITY_INSERT [Movie] ON;
INSERT INTO [Movie] (ID, TMDBID, Title, Overview, ReleaseDate)
VALUES
(1, 1011679, 'Shark Side of the Moon', 'Decades ago, the USSR developed unkillable sharks and launched them to the moon. Today, a team of American astronauts will endure the fight of their lives.', '2022-08-12'),
(2, 76600, 'Avatar: The Way of Water', 'Set more than a decade after the events of the first film, learn the story of the Sully family (Jake, Neytiri, and their kids), the trouble that follows them, the lengths they go to keep each other safe, the battles they fight to stay alive, and the tragedies they endure.', '2022-12-14')
SET IDENTITY_INSERT [Movie] OFF;

SET IDENTITY_INSERT [WatchList] ON;
INSERT INTO [WatchList] (ID, UserID, ListType)
VALUES
(1, 1, 0),
(7, 1, 1),
(2, 2, 0),
(3, 3, 0),
(4, 4, 0),
(5, 5, 0),
(6, 5, 1)
SET IDENTITY_INSERT [WatchList] OFF;

SET IDENTITY_INSERT [WatchListItems] ON;
INSERT INTO [WatchListItems] (ID, WatchListID, ShowID, MovieID)
VALUES
(1, 1, 1, null),
(2, 1, 2, null),
(3, 1, null, 1),
(4, 1, null, 2),
(5, 2, null, 1),
(6, 2, 1, null)
SET IDENTITY_INSERT [WatchListItems] OFF;

SET IDENTITY_INSERT [WatchPartyGroup] ON;
INSERT INTO [WatchPartyGroup] (ID, GroupTitle, GroupDescription, StartDate, HostID)
VALUES
(1, 'Marvel marathon movie night', null, '2023-05-05 20:00:00', 1),
(2, 'Harry Potter marathon', 'Going to watch all the Harry Potter movies in order all day', '2023-05-05 08:00:00', 5),
(3, 'Sports movies', 'Going to be watching sports movies such as More than a Game, The Last Dance, etc', '2023-05-05 14:00:00', 9)
SET IDENTITY_INSERT [WatchPartyGroup] OFF;

SET IDENTITY_INSERT [WatchPartyGroupAssignment] ON;
INSERT INTO [WatchPartyGroupAssignment] (ID, GroupID, WatcherID)
VALUES
(1, 1, 1),
(2, 1, 2),
(3, 1, 3),
(4, 2, 4),
(5, 2, 1),
(6, 2, 5),
(7, 2, 6),
(8, 2, 7),
(9, 3, 1),
(10, 3, 8),
(11, 3, 9),
(12, 3, 10)
SET IDENTITY_INSERT [WatchPartyGroupAssignment] OFF;

SET IDENTITY_INSERT [NotificationType] ON;
INSERT INTO [NotificationType] (ID, NType)
VALUES
(1, 'Follow Request'),
(2, 'Group Join Request'),
(3, 'Comment'),
(4, 'Like'),
(5, 'Watch Party Reminder'),
(6, 'Misc')
SET IDENTITY_INSERT [NotificationType] OFF;

SET IDENTITY_INSERT [Notification] ON;
INSERT INTO [Notification] (ID, NotifierID, NotifTypeID, Content, IsRead, CreatedAt)
VALUES
(1, 1, 5, 'Your watch party is scheduled for 4/25/13 at 6:00 pm', 0, '2023-04-22 12:00:00'),
(2, 1, 3, 'CarsonDaniel left a comment on your post', 0, '2023-04-22 12:05:00')
SET IDENTITY_INSERT [Notification] OFF;