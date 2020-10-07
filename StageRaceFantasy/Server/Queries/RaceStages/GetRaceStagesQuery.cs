using StageRaceFantasy.Shared.Models;
using System.Collections.Generic;

namespace StageRaceFantasy.Server.Queries.GetRaceStages
{
    public record GetRaceStagesQuery(int RaceId)
        : IApplicationQuery<List<GetRaceStageDto>>
    {
    }
}
