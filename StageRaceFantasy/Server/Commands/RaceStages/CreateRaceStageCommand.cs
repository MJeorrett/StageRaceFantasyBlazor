using StageRaceFantasy.Shared.Models;

namespace StageRaceFantasy.Server.Commands.RaceStages
{
    public record CreateRaceStageCommand(int RaceId, string StartLocation, string FinishLocation)
        : IApplicationCommand<GetRaceStageDto>
    {
    }
}
