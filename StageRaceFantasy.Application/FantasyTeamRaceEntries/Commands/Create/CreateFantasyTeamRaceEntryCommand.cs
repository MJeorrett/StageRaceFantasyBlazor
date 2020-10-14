using Microsoft.EntityFrameworkCore;
using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Common.Requests;
using StageRaceFantasy.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.FantasyTeamRaceEntries.Commands.Create
{
    public record CreateFantasyTeamRaceEntryCommand(int FantasyTeamId, int RaceId)
        : IApplicationRequest
    {
    }

    public class CreateFantasyTeamRaceEntryHandler : ApplicationRequestHandler<CreateFantasyTeamRaceEntryCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateFantasyTeamRaceEntryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<ApplicationRequestResult> Handle(
            CreateFantasyTeamRaceEntryCommand request,
            CancellationToken cancellationToken)
        {
            var raceId = request.RaceId;
            var teamId = request.FantasyTeamId;

            var raceExists = await _dbContext.Races.AnyAsync(x => x.Id == raceId);
            var teamExists = await _dbContext.FantasyTeams.AnyAsync(x => x.Id == teamId);

            if (!raceExists || !teamExists) return NotFound();

            var entry = new FantasyTeamRaceEntry()
            {
                RaceId = raceId,
                FantasyTeamId = teamId,
            };

            await _dbContext.FantasyTeamRaceEntries.AddAsync(entry, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Success();
        }
    }
}
