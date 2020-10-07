using StageRaceFantasy.Shared.Models;

namespace StageRaceFantasy.Server.Queries.GetRaceStages
{
    public record GetRaceStagesQuery(int RaceId)
        : IApplicationQuery<GetRaceStagesDto>
    {
    }
}
