using StageRaceFantasy.Application.Common.Requests;
using StageRaceFantasy.Domain.Entities;

namespace StageRaceFantasy.Application.Queries.RaceStages
{
    public record GetRaceStageQuery(int RaceId, int StageId)
        : IApplicationQuery<GetRaceStageDto>
    {
    }
}
