namespace StageRaceFantasy.Server.Commands.FanasyTeamRaceEntries
{
    public record AddRiderToFantasyTeamRaceEntryCommand(int TeamId, int RaceId, int RiderId)
        : IApplicationCommand
    {
    }
}
