using System.Collections.Generic;
using BaseballLeague.Domain;

namespace BaseballLeague.BLL
{
    public interface IBaseballLeagueManager
    {
        Response<Player> CreatePlayer(Player player);
        Response<Team> CreateTeam(Team team);
        Response<Player> DeletePlayer(int playerID);
        Response<List<Player>> GetALLPlayers();
        Response<List<Player>> GetAllPlayersInTeam(int teamID);
        Response<List<Team>> GetAllTeams();
        Response<List<Team>> GetAllTeamsInLeague(byte leagueID);
        Response<TradePlayer> TradePlayer(TradePlayer trader);
    }
}