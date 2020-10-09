using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Common.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.RaceStages.Commands.Update
{
    public record UpdateRaceStageCommand : IApplicationCommand
    {
        public int Id { get; init; }
        public int RaceId { get; init; }
        public string StartLocation { get; init; }
        public string FinishLocation { get; init; }
    }

    public class UpdateRaceStageHandler : ApplicationRequestHandler<UpdateRaceStageCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateRaceStageHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<ApplicationRequestResult> Handle(UpdateRaceStageCommand request, CancellationToken cancellationToken)
        {
            var raceId = request.RaceId;
            var stageId = request.Id;

            var stage = await _dbContext.RaceStages.FindAsync(new object[] { stageId }, cancellationToken);

            if (stage == null) NotFound();

            if (stage.RaceId != raceId) return BadRequest();

            stage.FinishLocation = request.FinishLocation;
            stage.StartLocation = request.StartLocation;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Success();
        }
    }
}
