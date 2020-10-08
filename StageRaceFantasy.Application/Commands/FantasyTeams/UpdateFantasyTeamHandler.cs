using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Common.Mediatr;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.Commands
{
    public class UpdateFantasyTeamHandler : ApplicationCommandHandler<UpdateFantasyTeamCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateFantasyTeamHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<CommandResult> Handle(UpdateFantasyTeamCommand request, CancellationToken cancellationToken)
        {
            var id = request.Id;
            var newName = request.Name;

            var team = await _dbContext.FantasyTeams.FindAsync(id);

            if (team == null) return NotFound();

            team.Name = newName;

            await _dbContext.SaveChangesAsync();

            return Success();
        }
    }
}
