using StageRaceFantasy.Server.Db;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Server.Commands
{
    public class UpdateFantasyTeamHandler : IApplicationCommandHandler<UpdateFantasyTeamCommand>
    {
        private readonly ApplicationDbContext _dbContext;

        public UpdateFantasyTeamHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CommandResult> Handle(UpdateFantasyTeamCommand request, CancellationToken cancellationToken)
        {
            var id = request.Id;
            var newName = request.Name;

            var team = await _dbContext.FantasyTeams.FindAsync(id);

            if (team == null)
            {
                return new()
                {
                    IsNotFound = true,
                };
            }

            team.Name = newName;

            await _dbContext.SaveChangesAsync();

            return new();
        }
    }
}
