using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace BaseballLeague.Domain
{
    public class Player
    {

        public int PlayerID { get; set; }
        
        [Required]
        public int TeamID { get; set; }

        [Required(ErrorMessage = "Must input a name")]
        public string PlayerName { get; set; }

        [Required]
        [Range(0, 99, ErrorMessage = "Can only enter up to two numbers.")]
        public int? JerseyNumber { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        public decimal? BattingAverage { get; set; }

        [Required]
        [Range(0, 35, ErrorMessage = "Enter a correct age.")]
        public int? YearsPlayed { get; set; }

        public Team Team { get; set; }
    }
}
