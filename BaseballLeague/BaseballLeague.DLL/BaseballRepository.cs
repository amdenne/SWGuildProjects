using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseballLeague.Domain;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;

namespace BaseballLeague.DLL
{
    public class BaseballRepository : IBaseballRepository
    {

        public List<Team> GetAllTeamsByLeague(byte LeagueID)
        {
            List<Team> teams = new List<Team>();

            using (var context = new Models.BaseballLeagueEntities())
            {
                var league = context.Teams.Where(x => x.LeagueID == LeagueID);

                foreach (var team in league)
                {
                    teams.Add(MapTeam(team));
                }
            }
            return teams;
        }

        public List<Player> GetAllPlayersByTeam(int TeamID)
        {
            List<Player> players = new List<Player>();

            using (var context = new Models.BaseballLeagueEntities())
            {
                var team = context.Players.Where(x => x.TeamID == TeamID);

                foreach(var p in team)
                {
                    players.Add(MapPlayer(p));
                }
            }
            return players;
        }

        public void CreateTeam(Team team)
        {
            using (var context = new Models.BaseballLeagueEntities())
            {
                Models.Team newTeam = new Models.Team();
                newTeam.Manager = team.Manager;
                newTeam.TeamName = team.TeamName;
                newTeam.LeagueID = team.LeagueID;

                context.Teams.Add(newTeam);
                context.SaveChanges();
            }
        }

        public void CreatePlayer(Player player)
        {
            using (var context = new Models.BaseballLeagueEntities())
            {
                Models.Player newPlayer = new Models.Player();
                newPlayer.PlayerName = player.PlayerName;
                newPlayer.JerseyNumber = (byte)player.JerseyNumber;
                newPlayer.Position = player.Position;
                newPlayer.BattingAverage =(decimal.Round(player.BattingAverage.Value, 3));
                newPlayer.YearsPlayed = (byte)player.YearsPlayed;
                newPlayer.TeamID = player.TeamID;

                context.Players.Add(newPlayer);
                context.SaveChanges();
            }
        }

        public void DeletePlayer(int PlayerID)
        {
            using (var context = new Models.BaseballLeagueEntities())
            {
                var player = context.Players.Where(x => x.PlayerID == PlayerID);

                foreach(var p in player)
                {
                    context.Players.Remove(p);
                }
                context.SaveChanges();
            }
        }

        public void TradePlayer(TradePlayer trader)
        {
            using (var context = new Models.BaseballLeagueEntities())
            {
                context.TradePlayer(trader.Team1ID, trader.Player1ID, trader.Team2ID, trader.Player2ID);

                context.SaveChanges();
            }
        }

        public void PlayerOnTeam(int PlayerID)
        {
            using (var context = new Models.BaseballLeagueEntities())
            {
                var player = context.GetPlayerAndTeamInfo(PlayerID);

                context.SaveChanges();
            }
        }

        public List<Player> GetAllPlayers()
        {
            List<Player> players = new List<Player>();

            using (var context = new Models.BaseballLeagueEntities())
            {
                var player = context.Players.ToList();
                foreach (var p in player)
                {
                    players.Add(MapPlayer(p));
                }

            }
            return players;
        }

        public List<Team> GetAllTeams()
        {
            List<Team> teams = new List<Team>();

            using (var context = new Models.BaseballLeagueEntities())
            {

                var team = context.Teams.ToList();
                foreach (var t in team)
                {
                    teams.Add(MapTeam(t));
                }
            }
            return teams;
        }

        private Team MapTeam(Models.Team from)
        {
            var to = new Team();
            //to.League = from.League;
            to.LeagueID = from.LeagueID;
            to.Manager = from.Manager;
            //to.Players = from.Players.ToList();
            to.TeamID = from.TeamID;
            to.TeamName = from.TeamName;
            return to;
        }

        private Player MapPlayer(Models.Player from)
        {
            var to = new Player();
            to.BattingAverage = (decimal.Round(from.BattingAverage.Value, 3)); 
            to.JerseyNumber = from.JerseyNumber;
            to.PlayerID = from.PlayerID;
            to.PlayerName = from.PlayerName;
            to.Position = from.Position;
            to.TeamID = from.TeamID;
            to.YearsPlayed = from.YearsPlayed;
            return to;

        }


    }
}
