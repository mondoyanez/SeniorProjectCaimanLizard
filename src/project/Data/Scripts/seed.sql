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
(1, 'Just watched The Shawshank Redemption', 'What an amazing movie! Highly recommended.', '2023-01-03 19:30:00', 1, 20),
(2, 'Game of Thrones finale', 'I have mixed feelings about the ending. What are your thoughts?', '2023-02-12 21:15:00', 1, 85),
(3, 'Inception', 'Mind-bending movie with a great plot twist.', '2023-03-05 14:45:00', 1, 42),
(4, 'Stranger Things Season 4', 'Can''t wait for the new season! Who else is excited?', '2023-04-10 10:00:00', 1, 73),
(5, 'Black Mirror', 'Each episode is like a mini-movie. Highly recommend if you enjoy dystopian themes.', '2023-01-25 16:20:00', 1, 56),
(6, 'Avengers: Endgame', 'Epic conclusion to the Infinity Saga. Marvel fans, you don''t want to miss this!', '2023-02-18 18:30:00', 1, 97),
(7, 'Breaking Bad', 'One of the best TV series ever made. The character development is phenomenal.', '2023-03-20 12:10:00', 1, 15),
(8, 'The Matrix', 'A mind-bending sci-fi movie that revolutionized the genre.', '2023-04-05 08:45:00', 1, 101),
(9, 'La La Land', 'A beautiful and enchanting musical. The music and cinematography are stunning.', '2023-03-10 17:30:00', 1, 64),
(10, 'The Witcher', 'Fantasy series with captivating storytelling and Henry Cavill as Geralt of Rivia.', '2023-04-15 14:20:00', 1, 33),
(11, 'The Mandalorian', 'This Star Wars series is a must-watch for any fan. Baby Yoda steals the show!', '2023-01-07 13:45:00', 1, 74),
(12, 'Pulp Fiction', 'A classic Quentin Tarantino movie with a star-studded cast and non-linear storytelling.', '2023-02-22 09:20:00', 1, 28),
(13, 'Stranger Things Season 5 predictions', 'What do you think will happen in the next season? Share your theories!', '2023-03-18 20:00:00', 1, 68),
(14, 'The Dark Knight', 'Heath Ledger''s portrayal of the Joker is legendary. One of the best superhero movies.', '2023-04-07 15:10:00', 1, 53),
(15, 'Breaking Bad spin-off', 'Who else would love to see a spin-off series focused on Jesse Pinkman?', '2023-01-29 11:30:00', 1, 39),
(16, 'The Lord of the Rings trilogy marathon', 'Planning a movie marathon weekend with the extended editions. Join me!', '2023-02-25 17:50:00', 1, 87),
(17, 'Stranger Things', 'Just finished watching the series for the first time. Mind-blowing!', '2023-03-25 10:15:00', 1, 16),
(18, 'Interstellar', 'A visually stunning sci-fi film with a thought-provoking storyline. Highly recommended.', '2023-04-12 12:40:00', 1, 104),
(19, 'The Office US vs The Office UK', 'Which version of The Office do you prefer? Let''s settle this debate!', '2023-03-15 18:05:00', 1, 62),
(20, 'The Crown', 'An excellent historical drama series that delves into the reign of Queen Elizabeth II.', '2023-04-18 14:30:00', 1, 30),
(21, 'Game of Thrones Season 9 Wishlist', 'Share your expectations and predictions for the next season of Game of Thrones!', '2023-03-10 09:30:00', 1, 45),
(22, 'Inception', 'Christopher Nolan''s mind-bending masterpiece. Prepare to have your reality questioned.', '2023-04-05 14:15:00', 1, 92),
(23, 'The Walking Dead', 'Who else is still hooked on this zombie-apocalypse series? Exciting twists!', '2023-05-03 17:20:00', 1, 21),
(24, 'Stranger Things Funko Pop Collection', 'Check out my growing Funko Pop collection featuring Stranger Things characters!', '2023-04-22 11:45:00', 1, 103),
(25, 'La La Land', 'A beautiful musical that captures the magic and struggles of pursuing dreams.', '2023-02-18 16:05:00', 1, 69),
(26, 'The Witcher', 'Henry Cavill nails the role of Geralt of Rivia in this epic fantasy series. A must-watch!', '2023-05-08 20:30:00', 1, 35),
(27, 'Black Mirror', 'An anthology series exploring the dark side of technology. Thought-provoking and unsettling.', '2023-03-29 13:55:00', 1, 81),
(28, 'The Godfather', 'A cinematic masterpiece that explores the world of organized crime. Timeless classic.', '2023-02-10 18:40:00', 1, 12),
(29, 'The Big Bang Theory', 'A hilarious sitcom that celebrates geek culture. Bazinga!', '2023-04-16 10:25:00', 1, 99),
(30, 'The Shawshank Redemption', 'A gripping tale of friendship and hope set in a prison. A must-see for all movie lovers.', '2023-03-02 12:00:00', 1, 63),
(31, 'Breaking Bad Marathon', 'Planning a weekend binge-watch of Breaking Bad. Who wants to join?', '2023-02-27 19:30:00', 1, 74),
(32, 'Avengers: Endgame', 'The epic conclusion to the Avengers saga. Prepare for an emotional rollercoaster!', '2023-03-18 16:45:00', 1, 29),
(33, 'The Crown', 'A riveting historical drama series that delves into the reign of Queen Elizabeth II.', '2023-04-08 10:20:00', 1, 88),
(34, 'The Matrix Trilogy', 'Rediscovering the mind-bending world of The Matrix. Join me for a movie marathon!', '2023-05-12 21:00:00', 1, 17),
(35, 'The Mandalorian', 'Baby Yoda steals the show in this Star Wars spin-off series. A must-watch for fans!', '2023-03-07 14:10:00', 1, 52),
(36, 'The Dark Knight', 'Heath Ledger delivers an iconic performance as the Joker in this superhero masterpiece.', '2023-04-20 18:35:00', 1, 96),
(37, 'Stranger Things Season 5 Speculations', 'Share your theories and predictions for the upcoming season of Stranger Things!', '2023-02-14 11:50:00', 1, 42),
(38, 'The Office Rewatch', 'Reliving the hilarious moments of The Office. Who else can never get enough?', '2023-03-31 15:15:00', 1, 101),
(39, 'Interstellar', 'Christopher Nolan takes us on a breathtaking journey through space and time.', '2023-04-28 13:25:00', 1, 7),
(40, 'Game of Thrones: Best Battles', 'Discuss and rank the most epic battles from Game of Thrones. Valar Morghulis!', '2023-05-10 09:50:00', 1, 80),
(41, 'The Witcher', 'The Witcher series on Netflix is a must-watch for fantasy fans. Share your favorite moments!', '2023-03-15 12:30:00', 1, 23),
(42, 'Inception', 'Christopher Nolan''s mind-bending thriller will leave you questioning reality. Highly recommended!', '2023-04-05 09:15:00', 1, 61),
(43, 'Black Mirror', 'Discuss the thought-provoking episodes of Black Mirror and their implications for the future.', '2023-05-02 17:45:00', 1, 93),
(44, 'Harry Potter Movie Marathon', 'Calling all Potterheads! Let''s relive the magic with a marathon of the Harry Potter movies.', '2023-05-08 14:20:00', 1, 12),
(45, 'The Walking Dead', 'Join the conversation about the latest twists and turns in The Walking Dead series.', '2023-02-22 20:10:00', 1, 34),
(46, 'Pulp Fiction', 'Quentin Tarantino''s classic crime film with an all-star cast. Discuss your favorite scenes!', '2023-03-25 18:00:00', 1, 79),
(47, 'Breaking Bad Finale', 'Relive the intense finale of Breaking Bad and share your thoughts on the ending.', '2023-04-15 13:55:00', 1, 105),
(48, 'The Great British Bake Off', 'Indulge in the delicious drama of The Great British Bake Off. Who will be crowned the winner?', '2023-05-06 11:30:00', 1, 16),
(49, 'The Shawshank Redemption', 'A timeless tale of hope and redemption. Discuss the impact of this classic movie.', '2023-02-18 16:40:00', 1, 68),
(50, 'Stranger Things Season 6 Wishlist', 'Share your hopes and predictions for the next season of Stranger Things!', '2023-03-10 10:05:00', 1, 99)
SET IDENTITY_INSERT [Post] OFF;

SET IDENTITY_INSERT [Comment] ON;
INSERT INTO [Comment](ID, CommentTitle, DatePosted, IsVisible, UserID, PostID)
VALUES
(1, 'I also thought that Friends was a great show', '2023-04-02 13:25:00', 1, 2, 3),
(2, 'I thought it was ok', '2023-04-02 14:00:00', 1, 3, 3),
(3, 'I respect your opinion @PagieCole', '2023-04-02 14:10:00', 0, 1, 3)
SET IDENTITY_INSERT [Comment] OFF;

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
INSERT INTO [WatchPartyGroup] (ID, GroupTitle, GroupDescription, StartDate, TelePartyURL, HostID)
VALUES
(1, 'Marvel marathon movie night', null, '2023-05-05 20:00:00', null, 1),
(2, 'Harry Potter marathon', 'Going to watch all the Harry Potter movies in order all day', '2023-05-05 08:00:00', 'https://redirect.teleparty.com/join/5ff6a69318b6a145', 5),
(3, 'Sports movies', 'Going to be watching sports movies such as More than a Game, The Last Dance, etc', '2023-05-05 14:00:00', 'https://redirect.teleparty.com/join/dad235b867e64fed', 9)
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