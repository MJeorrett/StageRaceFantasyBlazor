using Microsoft.EntityFrameworkCore;
using StageRaceFantasy.Server.Db;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Server.Commands.FanasyTeamRaceEntries
{
    public class UpdateFantasyTeamRaceEntryHandler : IApplicationCommandHandler<UpdateFantasyTeamRaceEntryCommand>
    {
        private readonly ApplicationDbContext _dbContext;

        public UpdateFantasyTeamRaceEntryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CommandResult> Handle(UpdateFantasyTeamRaceEntryCommand request, CancellationToken cancellationToken)
        {
            var teamId = request.FantasyTeamId;
            var raceId = request.RaceId;
            var riderIds = request.RiderIds; // TODO: Validate distinct.

            var entry = await _dbContext.FantasyTeamRaceEntries.FindAsync(teamId, raceId);

            if (entry == null)
            {
                return new()
                {
                    IsNotFound = true,
                };
            }

            var riders = await _dbContext.Riders
                .Where(x => riderIds.Contains(x.Id))
                .ToListAsync();

            if (riders.Count() != riderIds.Count())
            {
                return new()
                {
                    IsBadRequest = true,
                };
            }

            entry.Riders = riders;
            await _dbContext.SaveChangesAsync();

            return new();
        }
    }
}
