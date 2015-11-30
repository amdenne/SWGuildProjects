
Create Procedure CreatePlayer(
	@TeamID int,
	@PlayerName varchar(50),
	@JerseyNumber tinyint,
	@Position varchar(25),
	@BattingAverage decimal(3,0),
	@YearsPlayed tinyint
) AS
insert into Player (TeamID, PlayerName, JerseyNumber, Position, BattingAverage, YearsPlayed)
	values(
	@TeamID,
	@PlayerName,
	@JerseyNumber,
	@Position,
	@BattingAverage,
	@YearsPlayed)