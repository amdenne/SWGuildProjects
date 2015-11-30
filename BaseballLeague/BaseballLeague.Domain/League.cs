using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballLeague.Domain
{
    public class League
    {
        public League()
        {
            this.Teams = new List<Team>();
        }

        public byte LeagueID { get; set; }
        public string LeagueName { get; set; }

        public virtual List<Team> Teams { get; set; }
    }
}
