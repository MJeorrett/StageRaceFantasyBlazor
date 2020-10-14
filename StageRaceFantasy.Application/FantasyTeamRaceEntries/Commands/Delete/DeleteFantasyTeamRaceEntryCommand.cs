using Microsoft.EntityFrameworkCore;
using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Common.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.FantasyTeamRaceEntries.Commands.Delete
{
    public record DeleteFantasyTeamRaceEntryCommand(int FantasyTeamId, int RaceId)
        : IApplicationRequest
    {
    }

    public class DeleteFantasyTeamRaceEntryHandler : ApplicationRequestHandler<DeleteFantasyTeamRaceEntryCommand>
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
                .FirstOrDefaultAsync(
                    x => x.FantasyTeamId == teamId && x.RaceId == raceId,
                    cancellationToken);

            if (entry == null) return NotFound();

            _dbContext.FantasyTeamRaceEntries.Remove(entry);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Success();
        }
    }
}
