using StageRaceFantasy.Application.Common.Mediatr;
using StageRaceFantasy.Domain.Entities;
using System.Collections.Generic;

namespace StageRaceFantasy.Application.Queries.FantasyTeamRaceEntries
{
    public record GetAllFantasyTeamRaceEntriesQuery(int TeamId) : IApplicationQuery<List<GetAllFantasyTeamRaceEntriesDto>>
    {
    }
}
