using StageRaceFantasy.Application.Common.Mediatr;

namespace StageRaceFantasy.Application.Commands.FanasyTeamRaceEntries
{
    public record AddRiderToFantasyTeamRaceEntryCommand(int TeamId, int RaceId, int RiderId)
        : IApplicationCommand
    {
    }
}
