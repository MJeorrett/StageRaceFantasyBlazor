using StageRaceFantasy.Shared.Models;

namespace StageRaceFantasy.Server.Queries.RaceStages
{
    public record GetRaceStageQuery(int RaceId, int StageId)
        : IApplicationQuery<GetRaceStageDto>
    {
    }
}
