using Microsoft.EntityFrameworkCore;
using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Common.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.Commands.FanasyTeamRaceEntries
{
    public class DeleteFantasyTeamRaceEntryHandler : ApplicationCommandHandler<DeleteFantasyTeamRaceEntryCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteFantasyTeamRaceEntryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<ApplicationRequestResult> Handle(DeleteFantasyTeamRaceEntryCommand request, CancellationToken cancellationToken)
        {
            var teamId = request.FantasyTeamId;
            var raceId = request.RaceId;

            var entry = await _dbContext.FantasyTeamRaceEntries
                .FirstOrDefaultAsync(x => x.FantasyTeamId == teamId && x.RaceId == raceId);

            if (entry == null) return NotFound();

            _dbContext.FantasyTeamRaceEntries.Remove(entry);
            await _dbContext.SaveChangesAsync();

            return Success();
        }
    }
}
