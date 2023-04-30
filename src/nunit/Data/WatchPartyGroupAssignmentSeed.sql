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
(10, '561e79b0-24be-4f8b-96dd-056b593cd7c5', 'BobbieMcintyre', 'Bobbie', 'Mcintyre', null, NULL, 0),
(11, '261e79b0-24be-4f8b-96dd-056b593cd7c5', 'MondoYanez', 'Mondo', 'Yanez', null, null, 0);

INSERT INTO [WatchPartyGroup] (ID, GroupTitle, GroupDescription, StartDate, HostID)
VALUES
(1, 'Marvel marathon movie night', null, '2023-05-05 20:00:00', 1),
(2, 'Harry Potter marathon', 'Going to watch all the Harry Potter movies in order all day', '2023-05-05 08:00:00', 5),
(3, 'Sports movies', 'Going to be watching sports movies such as More than a Game, The Last Dance, etc', '2023-05-05 14:00:00', 9);

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
(12, 3, 10);