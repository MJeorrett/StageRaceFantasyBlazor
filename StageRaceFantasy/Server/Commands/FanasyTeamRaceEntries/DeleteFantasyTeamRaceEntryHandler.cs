using Microsoft.EntityFrameworkCore;
using StageRaceFantasy.Server.Db;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Server.Commands.FanasyTeamRaceEntries
{
    public class DeleteFantasyTeamRaceEntryHandler : IApplicationCommandHandler<DeleteFantasyTeamRaceEntryCommand>
    {
        private readonly ApplicationDbContext _dbContext;

        public DeleteFantasyTeamRaceEntryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CommandResult> Handle(DeleteFantasyTeamRaceEntryCommand request, CancellationToken cancellationToken)
        {
            var teamId = request.FantasyTeamId;
            var raceId = request.RaceId;

            var entry = await _dbContext.FantasyTeamRaceEntries
                .FirstOrDefaultAsync(x => x.FantasyTeamId == teamId && x.RaceId == raceId);

            if (entry == null)
            {
                return new()
                {
                    IsNotFound = true,
                };
            }

            _dbContext.FantasyTeamRaceEntries.Remove(entry);
            await _dbContext.SaveChangesAsync();

            return new();
        }
    }
}
