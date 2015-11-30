
Create Procedure CreateTeam(
	@LeagueID int, 
	@TeamName varchar(50), 
	@ManagerName varchar(50)
) AS
insert into Team (LeagueID, TeamName, Manager)
	values(
	@LeagueID,
	@TeamName,
	@ManagerName)