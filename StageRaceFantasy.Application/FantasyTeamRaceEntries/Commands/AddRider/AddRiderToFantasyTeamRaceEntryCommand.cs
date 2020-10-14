using Microsoft.EntityFrameworkCore;
using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Common.Requests;
using StageRaceFantasy.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.Commands.FanasyTeamRaceEntries
{
    public record AddRiderToFantasyTeamRaceEntryCommand(int TeamId, int RaceId, int RiderId)
        : IApplicationRequest
    {
    }

    public class AddRiderToFantasyTeamRaceEntryHandler : ApplicationRequestHandler<AddRiderToFantasyTeamRaceEntryCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public AddRiderToFantasyTeamRaceEntryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<ApplicationRequestResult> Handle(AddRiderToFantasyTeamRaceEntryCommand request,
                                                                    CancellationToken cancellationToken)
        {
            var teamId = request.TeamId;
            var raceId = request.RaceId;
            var riderId = request.RiderId;

            var raceEntry = await _dbContext.FantasyTeamRaceEntries
                .Include(x => x.FantasyTeamRaceEntryRiders)
                .FirstOrDefaultAsync(
                    x => x.FantasyTeamId == teamId && x.RaceId == raceId,
                    cancellationToken);

            var riderExists = await _dbContext.Riders
                .AnyAsync(x => x.Id == riderId, cancellationToken);

            if (raceEntry == null || !riderExists) return NotFound();

            var existingRider = raceEntry.FantasyTeamRaceEntryRiders.FirstOrDefault(x => x.RiderId == riderId);

            if (existingRider != null) return Success();

            raceEntry.FantasyTeamRaceEntryRiders.Add(new FantasyTeamRaceEntryRider()
            {
                FantasyTeamRaceEntryId = raceEntry.Id,
                RiderId = riderId,
            });

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Success();
        }
    }
}
