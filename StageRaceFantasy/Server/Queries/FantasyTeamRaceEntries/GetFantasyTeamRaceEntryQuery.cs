using StageRaceFantasy.Shared.Models;

namespace StageRaceFantasy.Server.Queries.FantasyTeamRaceEntries
{
    public record GetFantasyTeamRaceEntryQuery(int FantasyTeamId, int RaceId)
        : IApplicationQuery<GetFantasyTeamRaceEntryDto>
    {
    }
}
