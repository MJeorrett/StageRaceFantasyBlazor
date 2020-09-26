namespace StageRaceFantasy.Server.Commands.FanasyTeamRaceEntries
{
    public record RemoveRiderFromFantasyTeamRaceEntryCommand(int TeamId, int RaceId, int RiderId)
        : IApplicationCommand
    {
    }
}
