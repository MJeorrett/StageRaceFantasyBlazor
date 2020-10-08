using StageRaceFantasy.Application.Common;
using StageRaceFantasy.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.Commands.FantasyTeams
{
    public class CreateFantasyTeamHandler : IApplicationCommandHandler<CreateFantasyTeamCommand, FantasyTeam>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateFantasyTeamHandler(IApplicationDbContext dbContext)
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
