using System.Collections.Generic;
using BaseballLeague.Domain;

namespace BaseballLeague.DLL
{
    public interface IBaseballRepository
    {
        void CreatePlayer(Player player);
        void CreateTeam(Team team);
        void DeletePlayer(int PlayerID);
        List<Player> GetAllPlayersByTeam(int TeamID);
        List<Team> GetAllTeamsByLeague(byte LeagueID);
        void PlayerOnTeam(int PlayerID);
        void TradePlayer(TradePlayer trader);
        List<Player> GetAllPlayers();
        List<Team> GetAllTeams();
    }
}