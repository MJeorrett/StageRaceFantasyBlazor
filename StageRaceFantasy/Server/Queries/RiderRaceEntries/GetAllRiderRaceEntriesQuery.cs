using StageRaceFantasy.Shared.Models;
using System.Collections.Generic;

namespace StageRaceFantasy.Server.Queries.RiderRaceEntries
{
    public record GetAllRiderRaceEntriesQuery(int RaceId) : IApplicationQuery<List<GetRiderRaceEntryDto>>
    {
    }
}
