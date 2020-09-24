﻿using StageRaceFantasy.Shared.Models;
using System.Collections.Generic;

namespace StageRaceFantasy.Server.Queries
{
    public record GetAllRiderRaceEntriesQuery(int RaceId) : IApplicationQuery<List<GetRiderRaceEntryDto>>
    {
    }
}
