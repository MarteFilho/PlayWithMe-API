using Microsoft.EntityFrameworkCore;
using PlayWithMe.Models;

namespace PlayWithMe.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        { }
        public DbSet<Game> Game { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<PlayerGame> PlayerGame { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerGame>().HasKey(sc => new
            {
                sc.GameId,
                sc.PlayerID
            });
        }
    }


}
