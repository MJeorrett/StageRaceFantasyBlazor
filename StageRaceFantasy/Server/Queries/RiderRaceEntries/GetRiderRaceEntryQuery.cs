using StageRaceFantasy.Shared.Models;

namespace StageRaceFantasy.Server.Queries
{
    public record GetRiderRaceEntryQuery(int raceId, int riderId) : IApplicationQuery<GetRiderRaceEntryDto>
    {
    }
}
