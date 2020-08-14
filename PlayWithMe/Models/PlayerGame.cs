using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlayWithMe.Models
{
    public class PlayerGame
    {
        public int PlayerID { get; set; }
        public Player Player { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}
