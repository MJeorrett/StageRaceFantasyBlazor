using StageRaceFantasy.Application.Common.Mediatr;

namespace StageRaceFantasy.Application.Commands.FanasyTeamRaceEntries
{
    public record RemoveRiderFromFantasyTeamRaceEntryCommand(int TeamId, int RaceId, int RiderId)
        : IApplicationCommand
    {
    }
}
