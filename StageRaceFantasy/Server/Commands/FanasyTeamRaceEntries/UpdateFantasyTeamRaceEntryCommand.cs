using System.Collections.Generic;

namespace StageRaceFantasy.Server.Commands.FanasyTeamRaceEntries
{
    public record UpdateFantasyTeamRaceEntryCommand(int FantasyTeamId, int RaceId, List<int> RiderIds)
        : IApplicationCommand
    {
    }
}
