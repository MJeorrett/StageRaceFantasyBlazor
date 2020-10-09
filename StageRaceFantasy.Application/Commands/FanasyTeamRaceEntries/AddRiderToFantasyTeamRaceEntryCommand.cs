using StageRaceFantasy.Application.Common.Requests;

namespace StageRaceFantasy.Application.Commands.FanasyTeamRaceEntries
{
    public record AddRiderToFantasyTeamRaceEntryCommand(int TeamId, int RaceId, int RiderId)
        : IApplicationCommand
    {
    }
}
