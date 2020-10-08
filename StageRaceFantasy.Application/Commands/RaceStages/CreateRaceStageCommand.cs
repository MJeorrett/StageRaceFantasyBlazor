using StageRaceFantasy.Application.Common.Mediatr;
using StageRaceFantasy.Domain.Entities;

namespace StageRaceFantasy.Application.Commands.RaceStages
{
    public record CreateRaceStageCommand(int RaceId, string StartLocation, string FinishLocation)
        : IApplicationCommand<GetRaceStageDto>
    {
    }
}
