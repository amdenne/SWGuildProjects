using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseballLeague.Domain;
using BaseballLeague.DLL;

namespace BaseballLeague.BLL
{
    public class BaseballLeagueManager : IBaseballLeagueManager
    {
        private IBaseballRepository _repo;
        
        public BaseballLeagueManager()
        {
            _repo = new BaseballRepository();
        }
        public BaseballLeagueManager(IBaseballRepository repo)
        {
            _repo = repo;
        }

        public Response<Team> CreateTeam(Team team)
        {
            var response = new Response<Team>();
            var teams = _repo.GetAllTeamsByLeague(team.LeagueID);

            try
            {
                foreach (var t in teams)
                {
                    if (team.TeamName == t.TeamName)
                    {
                        response.Success = false;
                        response.Message = "There is already a team with that name in this league!";
                        return response;
                    }
                }
                _repo.CreateTeam(team);
                response.Success = true;
                response.Message = "Successfully created team.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<TradePlayer>TradePlayer(TradePlayer trader)
        {
            Response<TradePlayer> response = new Response<TradePlayer>();

            try
            {
                if (trader.Player1ID == trader.Player2ID)
                {
                    response.Success = false;
                    response.Message = "You cannot trade the same player!";
                }
                else if (trader.Team1ID == trader.Team2ID)
                {
                    response.Success = false;
                    response.Message = "you cannot trade to the same team!";
                }
                else
                {
                    _repo.TradePlayer(trader);
                    response.Success = true;
                    response.Message = "Successfully traded players.";
                }
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<Player> CreatePlayer(Player player)
        {
            var response = new Response<Player>();
            var players = _repo.GetAllPlayersByTeam(player.TeamID);

            try
            {
                foreach (var p in players)
                {
                    if (player.PlayerName == p.PlayerName)
                    {
                        response.Success = false;
                        response.Message = "That player already exists!";
                        return response;
                    }
                }
                _repo.CreatePlayer(player);
                response.Success = true;
                response.Message = "Successfully created player";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<List<Team>> GetAllTeamsInLeague(byte leagueID)
        {
            var response = new Response<List<Team>>();

            try
            {
                response.Data = _repo.GetAllTeamsByLeague(leagueID);
                response.Success = true;
                response.Message = "Success!";
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<List<Player>> GetAllPlayersInTeam(int teamID)
        {
            var response = new Response<List<Player>>();

            try
            {
                response.Data = _repo.GetAllPlayersByTeam(teamID);
                response.Success = true;
                response.Message = "Success!";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<Player> DeletePlayer(int playerID)
        {
            var response = new Response<Player>();
            var players = _repo.GetAllPlayers();

            try
            {
                foreach (var p in players)
                {
                    if (playerID == p.PlayerID)
                    {
                        _repo.DeletePlayer(playerID);
                        response.Success = true;
                        response.Message = "Sucessfully deleted player.";
                        return response;
                    }
                }
                response.Success = false;
                response.Message = "That player doesn't Exist!";
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<List<Player>> GetALLPlayers()
        {
            var response = new Response<List<Player>>();

            try
            {
                response.Data = _repo.GetAllPlayers();
                response.Success = true;
                response.Message = "Success.";
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<List<Team>> GetAllTeams()
        {
            var response = new Response<List<Team>>();

            try
            {
                response.Data = _repo.GetAllTeams();
                response.Success = true;
                response.Message = "Success.";
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
