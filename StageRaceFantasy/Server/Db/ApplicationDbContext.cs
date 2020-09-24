using Microsoft.EntityFrameworkCore;
using StageRaceFantasy.Shared.Models;

namespace StageRaceFantasy.Server.Db
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
            base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RiderRaceEntry>()
                .HasKey(x => new { x.RaceId, x.RiderId });
        }

        public DbSet<Rider> Riders { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<RiderRaceEntry> RiderRaceEntries { get; set; }
        public DbSet<FantasyTeam> FantasyTeams { get; set; }
    }
}
