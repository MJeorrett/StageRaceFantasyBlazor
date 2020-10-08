using StageRaceFantasy.Domain.Entities;
using System.Collections.Generic;

namespace StageRaceFantasy.Application.Queries
{
    public record GetAllRiderRaceEntriesQuery(int RaceId) : IApplicationQuery<List<GetRiderRaceEntryDto>>
    {
    }
}
