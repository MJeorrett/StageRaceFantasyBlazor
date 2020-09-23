using Microsoft.EntityFrameworkCore;
using StageRaceFantasy.Shared.Models;

namespace StageRaceFantasy.Server.Db
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
            base(options)
        { }

        public DbSet<Rider> Riders { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<RiderRaceEntry> RiderRaceEntries { get; set; }
    }
}
