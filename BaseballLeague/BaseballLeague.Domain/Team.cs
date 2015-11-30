using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballLeague.Domain
{
    public class Team
    {
        public List<Player> Players { get; set; }
        public Team()
        {
            this.Players = new List<Player>();
        }

        public int TeamID { get; set; }

        [Required]
        public byte LeagueID { get; set; }

        [Required]
        public string TeamName { get; set; }

        [Required]
        public string Manager { get; set; }

        public virtual League League { get; set; }
    }
}
