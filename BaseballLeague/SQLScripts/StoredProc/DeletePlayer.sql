Create Procedure DeletePlayer (@PlayerID int) as
Delete 
	from Player
	where PlayerID = @PlayerID