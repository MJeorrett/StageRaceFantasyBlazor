using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Common.Mediatr;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.Commands
{
    public class DeleteFantasyTeamHandler : IApplicationCommandHandler<DeleteFantasyTeamCommand>
    {
        private IApplicationDbContext _dbContext;

        public DeleteFantasyTeamHandler(IApplicationDbContext dbContext)
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
