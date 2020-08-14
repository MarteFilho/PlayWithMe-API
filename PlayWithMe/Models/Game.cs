using System.Collections.Generic;

namespace PlayWithMe.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Category { get; set; }
        public ICollection<PlayerGame> PlayerGame { get; set; }
    }
}