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

            modelBuilder.Entity<FantasyTeamRaceEntry>()
                .HasAlternateKey(x => new { x.FantasyTeamId, x.RaceId });

            modelBuilder.Entity<FantasyTeamRaceEntryRider>()
                .HasKey(x => new { x.FantasyTeamRaceEntryId, x.RiderId });

            modelBuilder.Entity<FantasyTeamRaceEntryRider>()
                .HasOne(x => x.FantasyTeamRaceEntry)
                .WithMany(x => x.FantasyTeamRaceEntryRiders)
                .HasForeignKey(x => x.FantasyTeamRaceEntryId);

            modelBuilder.Entity<FantasyTeamRaceEntryRider>()
                .HasOne(x => x.Rider)
                .WithMany(x => x.FantasyTeamRaceEntryRiders)
                .HasForeignKey(x => x.RiderId);
        }

        public DbSet<Rider> Riders { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<RiderRaceEntry> RiderRaceEntries { get; set; }
        public DbSet<FantasyTeam> FantasyTeams { get; set; }
        public DbSet<FantasyTeamRaceEntry> FantasyTeamRaceEntries { get; set; }
    }
}
