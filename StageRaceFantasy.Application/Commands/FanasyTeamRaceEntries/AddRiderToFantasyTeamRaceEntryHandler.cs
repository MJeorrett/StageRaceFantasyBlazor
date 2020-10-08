using Microsoft.EntityFrameworkCore;
using StageRaceFantasy.Application.Common;
using StageRaceFantasy.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.Commands.FanasyTeamRaceEntries
{
    public class AddRiderToFantasyTeamRaceEntryHandler : IApplicationCommandHandler<AddRiderToFantasyTeamRaceEntryCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public AddRiderToFantasyTeamRaceEntryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CommandResult> Handle(AddRiderToFantasyTeamRaceEntryCommand request, CancellationToken cancellationToken)
        {
            var teamId = request.TeamId;
            var raceId = request.RaceId;
            var riderId = request.RiderId;

            var raceEntry = await _dbContext.FantasyTeamRaceEntries
                .Include(x => x.FantasyTeamRaceEntryRiders)
                .FirstOrDefaultAsync(x => x.FantasyTeamId == teamId && x.RaceId == raceId);

            var riderExists = await _dbContext.Riders.AnyAsync(x => x.Id == riderId);

            if (raceEntry == null || !riderExists)
            {
                return new()
                {
                    IsNotFound = true,
                };
            }

            var existingRider = raceEntry.FantasyTeamRaceEntryRiders.FirstOrDefault(x => x.RiderId == riderId);
            if (existingRider != null)
            {
                return new();
            }

            raceEntry.FantasyTeamRaceEntryRiders.Add(new FantasyTeamRaceEntryRider()
            {
                FantasyTeamRaceEntryId = raceEntry.Id,
                RiderId = riderId,
            });

            await _dbContext.SaveChangesAsync();

            return new();
        }
    }
}
