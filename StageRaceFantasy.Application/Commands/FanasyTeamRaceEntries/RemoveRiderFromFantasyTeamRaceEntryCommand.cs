using StageRaceFantasy.Application.Common.Requests;

namespace StageRaceFantasy.Application.Commands.FanasyTeamRaceEntries
{
    public record RemoveRiderFromFantasyTeamRaceEntryCommand(int TeamId, int RaceId, int RiderId)
        : IApplicationCommand
    {
    }
}
