namespace StageRaceFantasy.Server.Commands.FanasyTeamRaceEntries
{
    public record DeleteFantasyTeamRaceEntryCommand(int FantasyTeamId, int RaceId)
        : IApplicationCommand
    {
    }
}
