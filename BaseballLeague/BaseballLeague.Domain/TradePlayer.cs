using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballLeague.Domain
{
    public class TradePlayer
    {
        [Required]
        public int Team1ID { get; set; }

        [Required]
        public int Player1ID { get; set; }

        [Required]
        public int Team2ID { get; set; }

        [Required]
        public int Player2ID { get; set; }
    }
}
