using StageRaceFantasy.Application.Common.Mediatr;
using StageRaceFantasy.Domain.Entities;

namespace StageRaceFantasy.Application.Queries.RaceStages
{
    public record GetRaceStageQuery(int RaceId, int StageId)
        : IApplicationQuery<GetRaceStageDto>
    {
    }
}
