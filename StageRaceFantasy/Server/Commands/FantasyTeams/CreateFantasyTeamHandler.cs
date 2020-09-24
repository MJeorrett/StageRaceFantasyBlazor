using StageRaceFantasy.Server.Db;
using StageRaceFantasy.Shared.Models;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Server.Commands.FantasyTeams
{
    public class CreateFantasyTeamHandler : IApplicationCommandHandler<CreateFantasyTeamCommand, FantasyTeam>
    {
        private readonly ApplicationDbContext _dbContext;

        public CreateFantasyTeamHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CommandResult<FantasyTeam>> Handle(CreateFantasyTeamCommand request, CancellationToken cancellationToken)
        {
            var fantasyTeam = new FantasyTeam()
            {
                Name = request.Name,
            };

            _dbContext.FantasyTeams.Add(fantasyTeam);

            await _dbContext.SaveChangesAsync();

            return new(fantasyTeam);
        }
    }
}
