Create Procedure TradePlayer (@Team1ID int, @Player1ID int, @Team2ID int, @Player2ID int) as

update Player
	set TeamID = @Team1ID
	where PlayerID = @Player2ID

update Player
	set TeamID = @Team2ID
	Where PlayerID = @Player1ID
	