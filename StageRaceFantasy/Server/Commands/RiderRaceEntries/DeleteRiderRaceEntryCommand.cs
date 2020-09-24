namespace StageRaceFantasy.Server.Commands.RiderRaceEntries
{
    public record DeleteRiderRaceEntryCommand(int RaceId, int RiderId) :
        IApplicationCommand
    {
    }
}
