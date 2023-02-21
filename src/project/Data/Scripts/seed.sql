SET IDENTITY_INSERT [Watcher] ON;
INSERT INTO [Watcher](ID, Username, FirstName, LastName, Email, FollowingCount, FollowerCount, Bio)
VALUES
('1', 'first', 'SandraHart', 'Sandra', 'Hart', 'SandraHart@email.com', 0, 0, NULL),
('2', 'second', 'CarsonDaniel', 'Carson', 'Daniel', 'DanielCarson@domain.net', 0, 0, NULL),
('3', 'third', 'PaigeCole', 'Paige', 'Cole', null, 0, 0, NULL),
('4', 'fourth', 'JaysonLawrence', 'Jayson', 'Lawrence', 'jLawrence@name.edu', 0, 0, NULL),
('5', 'fifth', 'GabrielGrant', 'Gabriel', 'Grant', 'gGabriel@differentMail.com', 0, 0, NULL),
('6', 'sixth', 'BradPorter', 'Brad', 'Porter', 'BradPorter@email.com', 0, 0, NULL),
('7', 'seventh', 'JudsonCooke', 'Judson', 'Cooke', null, 0, 0, NULL),
('8', 'eigth', 'SofiaCarpenter', 'Sofia', 'Carpenter', 'CarpenterSofia@mail.org', 0, 0, NULL),
('9', 'ninth', 'JosefMeyer', 'Josef', 'Meyer', 'JosefMeyer@mail.edu', 0, 0, NULL),
('10', 'tenth', 'BobbieMcintyre', 'Bobbie', 'Mcintyre', null, 0, 0, NULL);
SET IDENTITY_INSERT [Watcher] OFF;

SET IDENTITY_INSERT [Post] ON;
INSERT INTO [Post](ID, PostTitle, PostDescription, DatePosted, UserID)
VALUES
(1, 'Some generic name', 'This was incredible', '2023-01-15 17:00:00', 1),
(2, 'Some generic name', 'This was incredible', '2023-02-01 15:00:00', 3),
(3, 'Some generic name', 'This was incredible', '2023-02-08 08:00:00', 5),
(4, 'Some generic name', 'This was incredible', '2022-12-25 12:00:00', 7),
(5, 'Some generic name', 'This was incredible', '2023-02-03 13:00:00', 2),
(6, 'Some generic name', 'This was incredible', '2023-01-15 17:00:00', 6),
(7, 'Some generic name', 'This was incredible', '2023-01-15 17:00:00', 9),
(8, 'Some generic name', 'This was incredible', '2023-01-15 17:00:00', 10),
(9, 'Some generic name', 'This was incredible', '2023-01-15 17:00:00', 8),
(10, 'Some generic name', 'This was incredible', '2023-01-15 17:00:00', 4)
SET IDENTITY_INSERT [Post] OFF;

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