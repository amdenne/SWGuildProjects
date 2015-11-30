Create procedure GetPlayerAndTeamInfo
	(
	@playerID int
	)AS

select * from Player p
	join Team t on p.TeamID = t.TeamID
	where p.PlayerID = @playerID