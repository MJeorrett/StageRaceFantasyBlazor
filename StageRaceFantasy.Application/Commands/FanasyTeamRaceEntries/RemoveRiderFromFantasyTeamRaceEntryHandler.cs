using Microsoft.EntityFrameworkCore;
using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Common.Requests;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.Commands.FanasyTeamRaceEntries
{
    public class RemoveRiderFromFantasyTeamRaceEntryHandler : ApplicationRequestHandler<RemoveRiderFromFantasyTeamRaceEntryCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public RemoveRiderFromFantasyTeamRaceEntryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<ApplicationRequestResult> Handle(RemoveRiderFromFantasyTeamRaceEntryCommand request, CancellationToken cancellationToken)
        {
            var teamId = request.TeamId;
            var raceId = request.RaceId;
            var riderId = request.RiderId;

            var raceEntry = await _dbContext.FantasyTeamRaceEntries
                .Include(x => x.FantasyTeamRaceEntryRiders)
                .FirstOrDefaultAsync(x => x.FantasyTeamId == teamId && x.RaceId == raceId);

            if (raceEntry == null) return NotFound();

            var rider = raceEntry.FantasyTeamRaceEntryRiders.FirstOrDefault(x => x.RiderId == riderId);

            if (rider == null) return Success();

            raceEntry.FantasyTeamRaceEntryRiders.Remove(rider);
            await _dbContext.SaveChangesAsync();

            return Success();
        }
    }
}
