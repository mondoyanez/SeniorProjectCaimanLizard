SET IDENTITY_INSERT [Watcher] ON;
INSERT INTO [Watcher](ID, FirstName, LastName, Email)
VALUES
(1, 'Sandra', 'Hart', 'SandraHart@email.com'),
(2, 'Carson', 'Daniel', 'DanielCarson@domain.net'),
(3, 'Paige', 'Cole', null),
(4, 'Jayson', 'Lawrence', 'jLawrence@name.edu'),
(5, 'Gabriel', 'Grant', 'gGabriel@differentMail.com'),
(6, 'Brad', 'Porter', 'BradPorter@email.com'),
(7, 'Judson', 'Cooke', null),
(8, 'Sofia', 'Carpenter', 'CarpenterSofia@mail.org'),
(9, 'Josef', 'Meyer', 'JosefMeyer@mail.edu'),
(10, 'Bobbie', 'Mcintyre', null);
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