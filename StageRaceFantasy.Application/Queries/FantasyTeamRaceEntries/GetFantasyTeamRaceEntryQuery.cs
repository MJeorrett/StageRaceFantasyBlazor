using StageRaceFantasy.Domain.Entities;

namespace StageRaceFantasy.Application.Queries.FantasyTeamRaceEntries
{
    public record GetFantasyTeamRaceEntryQuery(int FantasyTeamId, int RaceId)
        : IApplicationQuery<GetFantasyTeamRaceEntryDto>
    {
    }
}
