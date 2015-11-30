﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BaseballLeague.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class BaseballLeagueEntities : DbContext
    {
        public BaseballLeagueEntities()
            : base("name=BaseballLeagueEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<League> Leagues { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
    
        public virtual ObjectResult<GetPlayerAndTeamInfo_Result> GetPlayerAndTeamInfo(Nullable<int> playerID)
        {
            var playerIDParameter = playerID.HasValue ?
                new ObjectParameter("playerID", playerID) :
                new ObjectParameter("playerID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetPlayerAndTeamInfo_Result>("GetPlayerAndTeamInfo", playerIDParameter);
        }
        
        public virtual int TradePlayer(Nullable<int> team1ID, Nullable<int> player1ID, Nullable<int> team2ID, Nullable<int> player2ID)
        {
            var team1IDParameter = team1ID.HasValue ?
                new ObjectParameter("Team1ID", team1ID) :
                new ObjectParameter("Team1ID", typeof(int));
    
            var player1IDParameter = player1ID.HasValue ?
                new ObjectParameter("Player1ID", player1ID) :
                new ObjectParameter("Player1ID", typeof(int));
    
            var team2IDParameter = team2ID.HasValue ?
                new ObjectParameter("Team2ID", team2ID) :
                new ObjectParameter("Team2ID", typeof(int));
    
            var player2IDParameter = player2ID.HasValue ?
                new ObjectParameter("Player2ID", player2ID) :
                new ObjectParameter("Player2ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("TradePlayer", team1IDParameter, player1IDParameter, team2IDParameter, player2IDParameter);
        }
    }
}