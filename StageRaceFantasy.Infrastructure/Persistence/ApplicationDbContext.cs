using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Domain.Entities;
using System.Threading.Tasks;

namespace StageRaceFantasy.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Rider> Riders { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<RaceStage> RaceStages { get; set; }
        public DbSet<RiderRaceEntry> RiderRaceEntries { get; set; }
        public DbSet<FantasyTeam> FantasyTeams { get; set; }
        public DbSet<FantasyTeamRaceEntry> FantasyTeamRaceEntries { get; set; }

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

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public override EntityEntry<T> Entry<T>(T entity) where T : class
        {
            return base.Entry<T>(entity);
        }
    }
}
