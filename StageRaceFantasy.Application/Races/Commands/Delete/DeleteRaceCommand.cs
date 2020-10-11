using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Common.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.Races.Commands.Delete
{
    public record DeleteRaceCommand(int Id) : IApplicationCommand
    {
    }

    public class DeleteRaceCommandHandler : ApplicationRequestHandler<DeleteRaceCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteRaceCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<ApplicationRequestResult> Handle(DeleteRaceCommand request, CancellationToken cancellationToken)
        {
            var raceId = request.Id;

            var race = await _dbContext.Races.FindAsync(new object[] { raceId }, cancellationToken);

            if (race == null) return NotFound();

            _dbContext.Races.Remove(race);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Success();
        }
    }
}
