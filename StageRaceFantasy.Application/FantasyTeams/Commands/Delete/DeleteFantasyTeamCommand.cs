using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Common.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.FantasyTeams.Commands.Delete
{
    public record DeleteFantasyTeamCommand(int Id) : IApplicationCommand
    {
    }

    public class DeleteFantasyTeamHandler : ApplicationCommandHandler<DeleteFantasyTeamCommand>
    {
        private IApplicationDbContext _dbContext;

        public DeleteFantasyTeamHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<ApplicationRequestResult> Handle(DeleteFantasyTeamCommand request, CancellationToken cancellationToken)
        {
            var id = request.Id;

            var fantasyTeam = await _dbContext.FantasyTeams.FindAsync(id);

            if (fantasyTeam == null) return NotFound();

            _dbContext.FantasyTeams.Remove(fantasyTeam);
            await _dbContext.SaveChangesAsync();

            return Success();
        }
    }
}
