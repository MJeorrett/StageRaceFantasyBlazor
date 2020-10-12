using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using StageRaceFantasy.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        EntityEntry<T> Entry<T>(T entity) where T : class;
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        DbSet<Rider> Riders { get; set; }
        DbSet<Race> Races { get; set; }
        DbSet<RaceStage> RaceStages { get; set; }
        DbSet<RiderRaceEntry> RiderRaceEntries { get; set; }
        DbSet<FantasyTeam> FantasyTeams { get; set; }
        DbSet<FantasyTeamRaceEntry> FantasyTeamRaceEntries { get; set; }
    }
}
