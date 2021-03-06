﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayWithMe.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Discord { get; set; }
        public string Country { get; set; }
        public string Password { get; set; }
        public ICollection<PlayerGame> PlayerGame { get; set; }
    }
}
