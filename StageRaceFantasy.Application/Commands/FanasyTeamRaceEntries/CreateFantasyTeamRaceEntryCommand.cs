﻿using StageRaceFantasy.Application.Common.Requests;
using StageRaceFantasy.Domain.Entities;

namespace StageRaceFantasy.Application.Commands.FanasyTeamRaceEntries
{
    public record CreateFantasyTeamRaceEntryCommand(int FantasyTeamId, int RaceId)
        : IApplicationCommand<GetFantasyTeamRaceEntryDto>
    {
    }
}
