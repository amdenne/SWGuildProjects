
Create Procedure GetAllTeamsInLeague(@LeagueID int) as

select * 
	from Team
	where LeagueID = @LeagueID