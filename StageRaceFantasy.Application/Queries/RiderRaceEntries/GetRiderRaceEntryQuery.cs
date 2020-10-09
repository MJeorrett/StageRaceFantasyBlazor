using StageRaceFantasy.Application.Common.Requests;
using StageRaceFantasy.Domain.Entities;

namespace StageRaceFantasy.Application.Queries
{
    public record GetRiderRaceEntryQuery(int raceId, int riderId) : IApplicationQuery<GetRiderRaceEntryDto>
    {
    }
}
