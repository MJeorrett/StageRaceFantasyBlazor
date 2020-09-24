using StageRaceFantasy.Server.Db;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Server.Commands
{
    public class DeleteFantasyTeamHandler : IApplicationCommandHandler<DeleteFantasyTeamCommand>
    {
        private ApplicationDbContext _dbContext;

        public DeleteFantasyTeamHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CommandResult> Handle(DeleteFantasyTeamCommand request, CancellationToken cancellationToken)
        {
            var id = request.Id;

            var fantasyTeam = await _dbContext.FantasyTeams.FindAsync(id);
            if (fantasyTeam == null)
            {
                return new()
                {
                    IsNotFound = true,
                };
            }

            _dbContext.FantasyTeams.Remove(fantasyTeam);
            await _dbContext.SaveChangesAsync();

            return new();
        }
    }
}
