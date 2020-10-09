using StageRaceFantasy.Application.Common.Requests;

namespace StageRaceFantasy.Application.Commands.FanasyTeamRaceEntries
{
    public record DeleteFantasyTeamRaceEntryCommand(int FantasyTeamId, int RaceId)
        : IApplicationCommand
    {
    }
}
