Create Procedure GetAllPlayersInTeam (@TeamID int) as
select * 
	from Player
	where TeamID = @TeamID