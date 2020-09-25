using StageRaceFantasy.Shared.Models;

namespace StageRaceFantasy.Server.Commands.FanasyTeamRaceEntries
{
    public record CreateFantasyTeamRaceEntryCommand(int FantasyTeamId, int RaceId)
        : IApplicationCommand<GetFantasyTeamRaceEntryDto>
    {
    }
}
