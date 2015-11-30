USE [BaseballLeague]
GO

INSERT INTO [dbo].[League]
           ([LeagueName])
     VALUES
           ('American'),
		   ('National')
GO


Insert into Team(LeagueID,TeamName, Manager)
	Values
		(1, 'Boston Red Sox', 'Alex Williams'),
		(2, 'Atlanta Braves', 'John Coppolella'),
		(2, 'Chicago Cubs', 'Joe Madden'),
		(1, 'Kansas City Royals', 'Ned Yost'),
		(1, 'Baltimore Orioles', 'Buck Showalter'),
		(1, 'Chicago White Sox', 'Robin Ventura'),
		(2, 'Cincinatti Reds', 'Bryan Price'),
		(2, 'St.Louis Cardinals', 'Mike Matheny')

GO

Insert into Player(TeamID, PlayerName, JerseyNumber, Position, BattingAverage, YearsPlayed)
		Values (2, 'Scott Downs', 5, 'RP', .000, 15),
			   (1,'Dustin Pedroia', 15, '2B', .299, 9),
			   (4,'Eric Hosmer', 35, '1B', .280, 4),
			   (6, 'Carlos Beltran', 36, 'RF', .280, 17),
			   (3, 'Jon Lester', 34, 'SP', .000, 9),
			   (5, 'Chris Davis', 19, '1B', .255, 7),
			   (8, 'Yadier Molina', 4, 'C', .283, 11),
			   (7, 'Jay Bruce', 32, 'RF', .248, 7),
			   (6, 'Mike Olt', 24, '3B', .168, 5),
			   (1, 'David Ortiz', 34, 'DH', .284, 18),
			   (2, 'Freddie Freeman', 5, '1B', .285, 5),
			   (3, 'Tsuyoshi Wada', 18, 'P', .246, 7),
			   (4, 'Alex Rios', 15, 'RF', .277, 11),
			   (5, 'Ubaldo Jimenez', 31, 'SP', .000, 9),
			   (6, 'John Danks', 50, 'SP', .000, 8),
			   (7, 'Bayan Pena', 29, 'C', .260, 10),
			   (8, 'Mark Reynolds', 12, '1B', .230, 8)

GO

