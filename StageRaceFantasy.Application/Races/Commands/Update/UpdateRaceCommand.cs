using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Common.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.Races.Commands.Update
{
    public record UpdateRaceCommand : IApplicationRequest
    {
        public int Id { get; set; }
        public string Name { get; init; }
        public int FantasyTeamSize { get; init; }
    }

    public class UpdateRaceCommandHandler : ApplicationRequestHandler<UpdateRaceCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateRaceCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<ApplicationRequestResult> Handle(UpdateRaceCommand request, CancellationToken cancellationToken)
        {
            var raceId = request.Id;

            var race = await _dbContext.Races.FindAsync(new object[] { raceId }, cancellationToken);

            if (race == null) return NotFound();

            race.Name = request.Name;
            race.FantasyTeamSize = request.FantasyTeamSize;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Success();
        }
    }
}
