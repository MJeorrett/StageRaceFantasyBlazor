using StageRaceFantasy.Server.Db;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Server.Commands.RaceStages
{
    public class UpdateRaceStageHandler : IApplicationCommandHandler<UpdateRaceStageCommand>
    {
        private readonly ApplicationDbContext _dbContext;

        public UpdateRaceStageHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CommandResult> Handle(UpdateRaceStageCommand request, CancellationToken cancellationToken)
        {
            var raceId = request.RaceId;
            var stageId = request.StageId;

            var stage = await _dbContext.RaceStages.FindAsync(stageId);

            if (stage == null)
            {
                return new()
                {
                    IsNotFound = true,
                };
            }

            if (stage.RaceId != raceId)
            {
                return new()
                {
                    IsBadRequest = true,
                };
            }

            stage.FinishLocation = request.FinishLocation;
            stage.StartLocation = request.StartLocation;

            await _dbContext.SaveChangesAsync();

            return new();
        }
    }
}
