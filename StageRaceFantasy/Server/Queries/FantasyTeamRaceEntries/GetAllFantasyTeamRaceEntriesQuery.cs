using StageRaceFantasy.Shared.Models;
using System.Collections.Generic;

namespace StageRaceFantasy.Server.Queries.FantasyTeamRaceEntries
{
    public record GetAllFantasyTeamRaceEntriesQuery(int TeamId) : IApplicationQuery<List<GetAllFantasyTeamRaceEntriesDto>>
    {
    }
}
