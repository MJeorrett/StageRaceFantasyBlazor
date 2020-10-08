using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Common.Mediatr;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.Commands.RaceStages
{
    public class UpdateRaceStageHandler : ApplicationCommandHandler<UpdateRaceStageCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateRaceStageHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<CommandResult> Handle(UpdateRaceStageCommand request, CancellationToken cancellationToken)
        {
            var raceId = request.RaceId;
            var stageId = request.StageId;

            var stage = await _dbContext.RaceStages.FindAsync(stageId);

            if (stage == null) NotFound();

            if (stage.RaceId != raceId) return BadRequest();

            stage.FinishLocation = request.FinishLocation;
            stage.StartLocation = request.StartLocation;

            await _dbContext.SaveChangesAsync();

            return Success();
        }
    }
}
