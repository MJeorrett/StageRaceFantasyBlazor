﻿using StageRaceFantasy.Application.Common.Mediatr;
using StageRaceFantasy.Domain.Entities;

namespace StageRaceFantasy.Application.Queries
{
    public record GetRiderRaceEntryQuery(int raceId, int riderId) : IApplicationQuery<GetRiderRaceEntryDto>
    {
    }
}
