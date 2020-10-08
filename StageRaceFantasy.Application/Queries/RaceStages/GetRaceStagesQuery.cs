using StageRaceFantasy.Domain.Entities;
using System.Collections.Generic;

namespace StageRaceFantasy.Application.Queries.GetRaceStages
{
    public record GetRaceStagesQuery(int RaceId)
        : IApplicationQuery<List<GetRaceStageDto>>
    {
    }
}
