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
(10, 'Avatar', 'Excited to watch the new Avatar movie that came out', '2023-01-15 17:00:00', 1, 4);