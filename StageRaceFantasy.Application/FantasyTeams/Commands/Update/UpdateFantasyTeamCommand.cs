using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Common.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.FantasyTeams.Commands.Update
{
    public record UpdateFantasyTeamCommand(int Id, string Name) : IApplicationRequest
    {
    }

    public class UpdateFantasyTeamHandler : ApplicationRequestHandler<UpdateFantasyTeamCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateFantasyTeamHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<ApplicationRequestResult> Handle(UpdateFantasyTeamCommand request, CancellationToken cancellationToken)
        {
            var id = request.Id;
            var newName = request.Name;

            var team = await _dbContext.FantasyTeams.FindAsync(new object[] { id }, cancellationToken: cancellationToken);

            if (team == null) return NotFound();

            team.Name = newName;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Success();
        }
    }
}
