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

INSERT INTO [NotificationType] (ID, NType)
VALUES
(1, 'Follow Request'),
(2, 'Group Join Request'),
(3, 'Comment'),
(4, 'Like'),
(5, 'Watch Party Reminder'),
(6, 'Misc');

INSERT INTO [Notification] (ID, NotifierID, NotifTypeID, Content, IsRead, CreatedAt)
VALUES
(1, 1, 5, 'Your watch party is scheduled for 4/25/13 at 6:00 pm', 0, '2023-04-22 12:00:00'),
(2, 1, 3, 'CarsonDaniel left a comment on your post', 0, '2023-04-22 12:05:00');