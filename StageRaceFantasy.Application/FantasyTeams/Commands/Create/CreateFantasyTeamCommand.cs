using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Common.Requests;
using StageRaceFantasy.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.FantasyTeams.Commands.Create
{
    public record CreateFantasyTeamCommand(string Name) : IApplicationRequest<FantasyTeam>
    {
    }

    public class CreateFantasyTeamHandler : ApplicationRequestHandler<CreateFantasyTeamCommand, FantasyTeam>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateFantasyTeamHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<ApplicationRequestResult<FantasyTeam>> Handle(CreateFantasyTeamCommand request, CancellationToken cancellationToken)
        {
            var fantasyTeam = new FantasyTeam()
            {
                Name = request.Name,
            };

            _dbContext.FantasyTeams.Add(fantasyTeam);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Success(fantasyTeam);
        }
    }
}
