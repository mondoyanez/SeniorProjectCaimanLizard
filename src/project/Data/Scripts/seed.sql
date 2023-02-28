SET IDENTITY_INSERT [Watcher] ON;
INSERT INTO [Watcher](ID, AspNetIdentityId, Username, FirstName, LastName, Email, FollowingCount, FollowerCount, Bio)
VALUES
(1, '571e79b0-24be-4f8b-96dd-056b493cd7c5', 'SandraHart', 'Sandra', 'Hart', 'SandraHart@email.com', 0, 0, NULL),
(2, '231e79b0-24be-4f8b-96dd-056b493cd7c5', 'CarsonDaniel', 'Carson', 'Daniel', 'DanielCarson@domain.net', 0, 0, NULL),
(3, '681e79b0-24be-4f8b-96dd-056b493cd7c5', 'PaigeCole', 'Paige', 'Cole', null, 0, 0, NULL),
(4, '561e79b0-24be-4f8b-96dd-056b493cd7c4', 'JaysonLawrence', 'Jayson', 'Lawrence', 'jLawrence@name.edu', 0, 0, NULL),
(5, '561e79b0-24be-4f8b-96dd-056b493cd7e5', 'GabrielGrant', 'Gabriel', 'Grant', 'gGabriel@differentMail.com', 0, 0, NULL),
(6, '561e79b0-24be-4f8b-96dd-056b493cd6c5', 'BradPorter', 'Brad', 'Porter', 'BradPorter@email.com', 0, 0, NULL),
(7, '561e79b0-24be-4f8b-96dd-056b493cd7p5', 'JudsonCooke', 'Judson', 'Cooke', null, 0, 0, NULL),
(8, '561e79b1-24be-4f8b-96dd-056b493cd7c5', 'SofiaCarpenter', 'Sofia', 'Carpenter', 'CarpenterSofia@mail.org', 0, 0, NULL),
(9, '561e79b0-24bf-4f8b-96dd-056b493cd7c5', 'JosefMeyer', 'Josef', 'Meyer', 'JosefMeyer@mail.edu', 0, 0, NULL),
(10, '561e79b0-24be-4f8b-96dd-056b593cd7c5', 'BobbieMcintyre', 'Bobbie', 'Mcintyre', null, 0, 0, NULL);
SET IDENTITY_INSERT [Watcher] OFF;

SET IDENTITY_INSERT [Post] ON;
INSERT INTO [Post](ID, PostTitle, PostDescription, DatePosted, UserID)
VALUES
(1, 'That new Ant-man movie was incredible!', null, '2023-01-15 17:00:00', 1),
(2, 'Spider-man', 'So excited for the new spider man movies!', '2023-02-01 15:00:00', 3),
(3, 'Friends', 'By far one of my favorite shows', '2023-02-08 08:00:00', 5),
(4, 'Best comedy of 2023?', null, '2022-12-25 12:00:00', 7),
(5, 'Might have been the best movie released in a while', null, '2023-02-03 13:00:00', 2),
(6, 'Who wants to watch a movie later', null, '2023-01-15 17:00:00', 6),
(7, 'The office was a good show', 'It was increible unlike anything else I''ve seen before', '2023-01-15 17:00:00', 9),
(8, 'Friends with friends', null, '2023-01-15 17:00:00', 10),
(9, 'MCU marathon', 'Who is down to have a MCU marathon sometime next week?', '2023-01-15 17:00:00', 8),
(10, 'Avatar', 'Excited to watch the new Avatar movie that came out', '2023-01-15 17:00:00', 4)
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