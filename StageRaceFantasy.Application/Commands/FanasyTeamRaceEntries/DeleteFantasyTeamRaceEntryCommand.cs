﻿using StageRaceFantasy.Application.Common.Mediatr;

namespace StageRaceFantasy.Application.Commands.FanasyTeamRaceEntries
{
    public record DeleteFantasyTeamRaceEntryCommand(int FantasyTeamId, int RaceId)
        : IApplicationCommand
    {
    }
}